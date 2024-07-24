
using System;
using System.Collections.Generic;

namespace Patterns.Behavioral_Patterns
{
    // Komut arayüzü
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Concrete Command
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    // Receiver
    public class Light
    {
        public void On()
        {
            Console.WriteLine("The light is on");
        }

        public void Off()
        {
            Console.WriteLine("The light is off");
        }
    }

    // Invoker
    public class RemoteControl
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command.Execute();
        }

        public void PressUndo()
        {
            _command.Undo();
        }
    }

    class Command_Pattern
    {
        static void Main(string[] args)
        {
            Light livingRoomLight = new Light();
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            RemoteControl remote = new RemoteControl();

            // Işığı aç
            remote.SetCommand(lightOn);
            remote.PressButton();

            // Işığı kapat
            remote.SetCommand(lightOff);
            remote.PressButton();

            // Son işlemi geri al
            remote.PressUndo();
        }
    }
}

