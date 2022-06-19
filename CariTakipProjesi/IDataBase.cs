using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CariTakipProjesi
{
    interface IDataBase
    {

        void DataAdd(IPerson person,IIslem islem);
        void DataDelete(IPerson person);
        void DataUpdate(IPerson person);
        void DataSearch(IPerson person, string metin,string tur);
        void GetAll(IPerson person);
        void GetIslem(IPerson person,IIslem islem);
        void IslemAdd(IIslem islem, IPerson person);
        void IslemUpdate(IIslem islem,IPerson person);
        void IslemDelete(IIslem islem,IPerson person);



    }
}
