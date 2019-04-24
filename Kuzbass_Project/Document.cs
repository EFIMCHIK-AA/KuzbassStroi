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
        private String _Name, _Number,_Status, _QR, _NumberDoc, _Executor,_List,_Lenght,_Weight; //name - марка
        DateTime _DateCreate;

        //Конструкторы
        public Document() : this("Не задано", "Нет номера", "Нет статуса", "Нет QR", "Нет длины", "Нет веса", "Нет листа","Нет исполнителя",new DateTime(),"Нет номера бланка") { }

        public Document(String _Name, String _Number, String _Status, String _QR, String _Lenght, String _Weight, String _List, String _Executor, DateTime _DateCreate, String _NumberDoc)
        {   
            this._Name = _Name.Trim() != "" ? _Name.Trim() : "Нет марки";
            this._Number = _Number.Trim() != "" ? _Number.Trim() : "Нет номера";
            this._Status = _Status.Trim() != "" ? _Status.Trim() : "Нет статуса";
            this._QR = _QR.Trim() != "" ? _QR.Trim() : "Нет QR";
            this._Lenght = _Lenght.Trim() != "" ? _Lenght.Trim() : "Нет длины";
            this._Weight = _Weight.Trim() != "" ? _Weight.Trim() : "Нет веса";
            this._List = _List.Trim() != "" ? _List.Trim() : "Нет листа";
            this._Executor = _Executor.Trim() != "" ? _Executor.Trim() : "Нет исполнителя";
            this._DateCreate = _DateCreate.ToString().Trim() != "" ? _DateCreate : new DateTime();
            this._NumberDoc = _NumberDoc.Trim() != "" ? _NumberDoc.Trim() : "Нет номера бланка";
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
                if (value.Trim() != "")
                {
                    _Name = value.Trim();
                }
            }
        }

        public String Executor
        {
            get
            {
                return _Executor;
            }
            set
            {
                if(value.Trim() != "")
                {
                    _Executor = value.Trim();
                }
            }
        }

        public String List
        {
            get
            {
                return _List;
            }
            set
            {
                if (value.Trim() != "")
                {
                    _List = value.Trim();
                }
            }
        }

        public String Lenght
        {
            get
            {
                return _Lenght;
            }
            set
            {
                if (value.Trim() != "")
                {
                    _Lenght = value.Trim();
                }
            }
        }

        public String Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                if (value.Trim() != "")
                {
                    _Weight = value.Trim();
                }
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
                if (value.Trim() != "")
                {
                    _Number = value.Trim();
                }
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
                if (value.Trim() != "")
                {
                    _NumberDoc = value.Trim();
                }
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
                if (value.Trim() != "")
                {
                    _Status = value.Trim();
                }
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
                if (value.Trim() != "")
                {
                    _QR = value.Trim();
                }
            }
        }

        public DateTime DateCreate
        {
            get
            {
                return _DateCreate;
            }
            set
            {
                _DateCreate = value;
            }
        }

        //Перегрузка ToString для отображения в Spisok_LB
        public override String ToString() => $"Номер заказа {_Number} Марка: {_Name} Лист: {_List}";

        //Метод для отображения в ResultSpisok_LB
        public String ToStringSuccessfully() => $"Номер заказа {_Number} Марка: {_Name} Лист: {_List} подтвержден";

        //Метод для отображения в ResultSpisok_LB
        public String ToStringSAdd() => $"Номер заказа {_Number} Марка: {_Name} Лист: {_List} добавлен";

    }
}
