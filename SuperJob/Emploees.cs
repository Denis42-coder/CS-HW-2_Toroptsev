using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperJob
{
    abstract class Emploees: IComparable
    {
        protected Emploees(string name, string position, bool describePrice)
        {
            Name = name;
            Position = position;
            DescribePrice = describePrice;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public bool DescribePrice { get; set; }

        public abstract double HPrice(double HRate);

        public abstract double FPrice(double FRate);

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj);
        }
    }

    class HourPrice : Emploees
    {
        public HourPrice(string Name, string Position, bool DescribePrice) : base(Name, Position, DescribePrice)
        {

        }

        public override double FPrice(double FRate)
        {
            throw new NotImplementedException();
        }

        public override double HPrice(double HRate)
        {
            return 20.8 * 8 * HRate;
        }
    }

    class FixPrice : Emploees
    {
        public FixPrice(string Name, string Position, bool DescribePrice) : base(Name, Position, DescribePrice)
        {

        }

        public override double HPrice(double HRate)
        {
            throw new NotImplementedException();
        }

        public override double FPrice(double FRate)
        {
            return FRate;
        }
    }

    public class Work
    {
        string fileName;
        int index;
        List<Emploees> list;
               
        public int CurrentIndex
        {
            get { return index; }
        }

        public void Next()
        {
            if (list.Count > index + 1) index++; else index = 0; ;
        }

        public void Prev()
        {
            if (index > 0) index--; else index = 0; ;
        }

        //public void Add(Emploees employee)
        //{
        //    list.Add(employee);
        //    index = list.Count - 1;
        //}

        public void Remove()
        {
            list.RemoveAt(index);
            Prev();
        }

        public void Emploee()
        {
            list = new List<Emploees>();
            index = -1;
        }

        //public Emploees CurrentEmployee
        //{
        //    get
        //    {
        //        try
        //        {
        //            return list[index];
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}

        public void Save(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Emploees>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
            index = 0;
        }

        public void Load(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Emploees>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Emploees>)xmlFormat.Deserialize(fStream);
            fStream.Close();
            index = 0;
        }
    }
    
}
