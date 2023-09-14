namespace AspnetCoreTemplates.Extensions
{
    public static class ConsoleToolsExtensions
    {
        private static DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar progressBar = new DustInTheWind.ConsoleTools.Controls.Spinners.ProgressBar();

        public static void ShowProgressBar()
        {
            #region  Bar
            ManualResetEventSlim finishEvent = new ManualResetEventSlim();
            finishEvent.Reset();

            Task.Run<Task>(async () =>
            {
                progressBar.Display();

                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(100);
                    progressBar.Value++;
                }

                finishEvent.Set();
            });

            finishEvent.Wait();

            progressBar.Close();

            #endregion
        }

        public static void HideProgressBar()
        {
            progressBar.Close();
        }
    }
}
