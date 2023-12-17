namespace Common
{
    public class ResourceLockManager
    {
        private static object Lock = new();
        private static bool _resourceReady;
        private static TaskCompletionSource<bool> _completionSource = null!;

        public static Task WaitForResourceAsync()
        {
            lock (Lock)
            {
                if (_resourceReady)
                {
                    return Task.CompletedTask;
                }

                _completionSource = new TaskCompletionSource<bool>();
            }

            return _completionSource.Task;
        }

        public static void ResourceAvailable()
        {
            lock (Lock)
            {
                if (!_resourceReady)
                {
                    _resourceReady = true;
                    _completionSource?.SetResult(true);
                }
            }
        }
    }
}