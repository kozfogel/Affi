using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affi
{
    class Affinfo
    {
        public int TargetAffinitiy;
        public String Name;

        public Affinfo(string line)
        {
            string name = line.Split(':')[0];
            string affi = line.Split(':')[1];
            
            while (affi.Length < Environment.ProcessorCount)
                affi += "0";

            string raffi = Reverse(affi);

            int newAffinity = Convert.ToInt32(raffi, 2);
            this.TargetAffinitiy = newAffinity;
            this.Name = name;

            Console.WriteLine("Create target: " + this.Name + " (" + this.TargetAffinitiy + " = " + affi + ")");
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
