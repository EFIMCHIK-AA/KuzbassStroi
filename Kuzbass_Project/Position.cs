using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzbass_Project
{
    class Position
    {
        private String _Name, _HashPass;

        public Position() : this("Нет названия", "Нет пароля") { }

        public Position(String Name, String HashPass)
        {
            _Name = Name.Trim() != "" ? Name.Trim() : "Нет названия";
            _HashPass = HashPass.Trim() != "" ? HashPass.Trim() : "Нет пароля";
        }

        public String Name
        {
            get
            {
                return _Name;
            } 

            set
            {
                if(value.Trim() != "")
                {
                    _Name = value;
                }
            }
        }

        public String HashPass
        {
            get
            {
                return _HashPass;
            }

            set
            {
                if (value.Trim() != "")
                {
                    _HashPass = value;
                }
            }
        }
    }
}
