using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZUS_Transport.Classes
{
     class GeneralClass
    {
        public enum Status { Admin = 1, Client = 2 , Director = 3, Economist = 4, DispatcherNIIAR = 5, Department =6, DispatcherATA  = 7}
        public static int mode { get; set; } //Режим доступа
        public static string nickname { get; set; }//ник

        public static string client { get; set; }//Ф.И.О. Клиента
        public static string email { get; set; }
        public static string post { get; set; }
        public static string division { get; set; }
        public static string building { get; set; }
        public static string room { get; set; }
        public static string workPhone { get; set; }
        public static string mobilePhone { get; set; }
        public static string directorClient { get; set; }
        public static string economistClient { get; set; }
        public static int UserID { get; set; }// ID клиента

        public static string statusUser { get; set; }


        public static string ModelCar { get; set; }
        public static string RegisterSign { get; set; }


        public static int bsPosition { get; set; }
        public static int bsPositionAgreed { get; set; }


        public static int applicationJoin { get; set; }

        public static string login { get; set; }
        public static string password { get; set; }


    }
}
