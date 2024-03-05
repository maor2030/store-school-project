using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaorSaban215713587.utilities;

namespace MaorSaban215713587.Class
{
    class clients {

        private string id;
        private string username;
        private string password;
        private string address;
        private string birthDay;

        public string Id
        {
            set {
                if (ValidationsUtilities.IsLegalId(value)) {
                    this.id = value;
                }
                else
                {
                    throw new Exception("Invalid id");
                }
            }
            get
            {
                return this.id;
            }
        }

        public string Username
        {
            set
            {
                this.username = value;
            }
            get
            {
                return this.username;
            }
        }

        public string Password
        {
            set
            {
              this.password = value;
            }
            get
            {
                return this.password;
            }
        }

        public string Adress
        {
            set
            {
                this.address = value;
            }
            get
            {
                return this.address;
            }
        }

        public string Birthday
        {
            set
            {
                 this.birthDay = value;
            }
            get
            {
                return this.birthDay;
            }
        }

    }
    
}
