namespace oop_practice
{
    class Delegates_events
    {
        static void Main()
        {
            Process process = new Process();
            process.ProcessCompleted += () => Console.WriteLine
           ("Process Completed!");
            process.StartProcess();
        }
    }

    public delegate void Notify();

    public class Process
    {
        public event Notify? ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started");
            OnProcessCompleted();
        }
        protected virtual void OnProcessCompleted()
        {
            // ProcessCompleted null değilse olayın tetiklenmesini sağlar
            ProcessCompleted?.Invoke();
        }

    }
}
