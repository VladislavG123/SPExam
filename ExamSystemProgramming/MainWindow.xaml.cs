using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamSystemProgramming
{
    public partial class MainWindow : Window
    {
        private DownloadInfo _info;
        public MainWindow()
        {
            InitializeComponent();
            _info = new DownloadInfo();
        }

        private void RunButtonClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTextBox.Text, out int result) && result > 0 && result <= 1000)
            {
                int[] numbers = new int[result + 1];
                Thread[] threads = new Thread[result];

                for (int i = 0; i < result; i++)
                {
                    threads[i] = new Thread(() => { numbers[i] = i + 1; });
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                return;
            }
            MessageBox.Show("Количество должно быть больше нуля и меньше тысячи!");
        }

        private async void DownloadButtonClick(object sender, RoutedEventArgs e)
        {
            _info.Url = urlTextBox.Text;
            _info.LocalPath = $"{Guid.NewGuid().ToString()}_File";

            try
            {
                await SendToDatabase(_info, new State { DownloadInfo = _info, Status = "Begin", DateTime = DateTime.Now });

                await DownloadFile(_info.Url, _info.LocalPath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            MessageBox.Show("Файл установлен!");
            _info = new DownloadInfo();
        }


        private Task DownloadFile(string url, string localPath)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.DownloadFileAsync(new Uri(url), localPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла ошибка. Проверьте правильность введенного Url");
                    return Task.FromException<Exception>(new Exception());
                }

            }
            return Task.CompletedTask;
        }

        private Task SendToDatabase(DownloadInfo info, State state)
        {
            return Task.Run(() =>
            {
                using (var context = new AppContext())
                {
                    var elements = context.DownloadInfos.Where(downloadInfo => downloadInfo.Id == info.Id);
                    if (elements is null)
                    {
                        context.DownloadInfos.Add(info);
                        context.SaveChanges();
                    }

                    context.States.Add(state);
                    context.SaveChanges();
                }
            });
        }
    }
}
