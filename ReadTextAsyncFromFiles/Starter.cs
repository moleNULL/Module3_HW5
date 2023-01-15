namespace ReadTextAsyncFromFiles
{
    internal class Starter
    {
        private static readonly string _helloFile = "Hello.txt";
        private static readonly string _worldFile = "World.txt";
        public static void Run()
        {
            var task = ReadAsync();
            Console.WriteLine(task.Result);
        }

        private static async Task<string> ReadHelloTextAsync()
        {
            return await File.ReadAllTextAsync(_helloFile);
        }

        private static async Task<string> ReadWorldTextAsync()
        {
            return await File.ReadAllTextAsync(_worldFile);
        }

        private static async Task<string> ReadAsync()
        {
            var taskHello = ReadHelloTextAsync();
            var taskWorld = ReadWorldTextAsync();

            await Task.WhenAll(taskHello, taskWorld);

            return taskHello.Result + ", " + taskWorld.Result + "!";
        }
    }
}
