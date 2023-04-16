using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    internal class CurrentList // класс, в котором находятся общие параметры - лист, объект класса листа, использование контекста для обращения к базе данных
    {
        public static Children children; // экземпляр класса таблицы
        public static List<Children> childrenList = new List<Children>(); // лист с параметрами класса талицы в базе данных
        public static ExapPreparationEfContext db = new ExapPreparationEfContext(); // для обращения и операций с базой данных
    }
}
