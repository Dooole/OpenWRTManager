using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWRTManager
{
    class Login
    {
        private Logger loginLogger;
        private Console loginConsole;
        private Command loginCommand;

        public Login(Logger logger, Console console, Command command)
        {
            this.loginLogger = logger;
            this.loginConsole = console;
            this.loginCommand = command;
        }

        public bool SignIn(string user, string password)
        {
            this.loginLogger.Print(String.Format("Try to login with user '{0}' and psw '{1}'",
                user, password));

            string output;
            int retries = 7;
            bool login_ready = false;
            while (retries > 0 && !login_ready)
            {
                retries--;

                output = this.loginConsole.ReceiveLine();
                if (Command.IsReadyOutput(output))
                {
                    this.loginLogger.Print("Already logged in");
                    return true;
                }
                else if (Command.IsLoginOutput(output))
                {
                    login_ready = true;
                    break;
                }

                this.loginConsole.Send("");
                Thread.Sleep(500); // 0.5 sec
            }

            if (!login_ready)
            {
                this.loginLogger.Print("Failed to recv login prompt");
                return false;
            }

            this.loginConsole.Send(user);
            this.loginConsole.Send(password);

            output = this.loginConsole.Receive();
            if (Command.IsIncorrectdOutput(output))
            {
                this.loginLogger.Print("Incorrect password");
                return false;
            }

            output = this.loginCommand.Send("echo testing123");
            if (output.IndexOf("testing123") == -1)
            {
                this.loginLogger.Print("Console test failed");
                return false;
            }

            return true;
        }

        public void SignOut()
        {
            this.loginLogger.Print("Signing Out!");
            this.loginCommand.Send("exit");
        }
    }
}
