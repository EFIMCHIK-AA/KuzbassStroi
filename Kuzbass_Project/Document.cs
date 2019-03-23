using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzbass_Project
{
    class Document
    {
        //Поля
        private String _Name, _Number,_Status, _QR, _NumberDoc;

        //Конструкторы
        public Document() : this("Не задано", "Нет номера", "Нет статуса", "Нет QR") { }

        public Document(String _Name, String _Number, String _Status, String _QR)
        {   
            this._Name = _Name.Trim() != "" ? _Name.Trim() : "Не задано";
            this._Number = _Number.Trim() != "" ? _Number.Trim() : "Нет номера";
            this._Status = _Status.Trim() != "" ? _Status.Trim() : "Нет статуса";
            this._QR = _QR.Trim() != "" ? _QR.Trim() : "Нет QR";
        }

        //Свойства
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value.Trim() != "" ? value.Trim() : "Не задано";
            }
        }

        public String Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value.Trim() != "" ? value.Trim() : "Нет номера"; ;
            }
        }

        public String NumberDoc
        {
            get
            {
                return _NumberDoc;
            }
            set
            {
                _NumberDoc = value;
            }
        }

        public String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value.Trim() != "" ? value.Trim() : "Нет статуса";
            }
        }

        public String QR
        {
            get
            {
                return _QR;
            }
            set
            {
                _QR = value.Trim() != "" ? value.Trim() : "Нет QR"; ;
            }
        }

        //Перегрузка ToString для отображения в Spisok_LB
        public override String ToString() => $"Документ {_Name} QR: {_QR}";

        //Метод для отображения в ResultSpisok_LB
        public String ToStringSuccessfully() => $"Документ {_Name} QR: {_QR} подтвержден";

    }
}
