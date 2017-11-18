using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace affi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total # of processors: {0}", Environment.ProcessorCount);

            var readTxt = File.ReadAllLines("affi.txt");

            List<Affinfo> affis = new List<Affinfo>();

            foreach(var l in readTxt)
            {
                affis.Add(new Affinfo(l));
            }


            while(true)
            {
                Console.WriteLine("Scanning ...");
                foreach(var p in Process.GetProcesses())
                {
                    foreach (Affinfo ai in affis)
                        if(p.ProcessName.ToLower() == ai.Name.ToLower())
                            if(p.ProcessorAffinity != (System.IntPtr)ai.TargetAffinitiy)
                            {
                                Console.WriteLine("found: " + ai.Name + " set to " + ai.TargetAffinitiy);
                                p.ProcessorAffinity = (System.IntPtr)ai.TargetAffinitiy;
                            }
                }

                Thread.Sleep(5000);
            }
            
        }
    }
}
