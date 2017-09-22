using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    public class Versions
    {
        public const char SPLITER = '┃';// '\n';
        BindingList<Branch> branches = new BindingList<Branch>();

        public Versions(string version)
        {
            if (version.Trim() == "")
                return;

            foreach (string i in version.Split(Versions.SPLITER))
            {
                this.DIV();
                foreach (string j in i.Split(Branch.SPLITER))
                {
                    string[] p = j.Split('┆').ToArray();
                    if (p.Count() != 2)
                        throw new Exception(j);
                    Push(p[0], p[1]);
                }
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (Branch i in branches)
            {
                result += i.ToString() + SPLITER;
            }
            return result.TrimEnd(SPLITER);
        }

        public void DIV()
        {
            branches.Add(new Branch());
        }

        public void Push(string ver, string lot)
        {
            int index = branches.Count - 1;
            if (branches.Count == 0)
                throw new Exception("No Branche");

            Pair p = new Pair();
            p.VER = ver;
            p.LOT = lot;
            branches[index].Push(ver, lot);
        }

        public string[] GET()
        {
            List<string> result = new List<string>();

            string ver = this.ToString();//"M11,V001|M12,V002*M21,V003|M22,V004";

            Regex regex = new Regex(@"(?<A>[\D|\d]+)┆(?<B>[\D|\d]+)");


            foreach (string i in ver.ToString().Split(Versions.SPLITER))
            {
                foreach (string j in i.Split(Branch.SPLITER))
                {
                    Match match = regex.Match(j);

                    if (match.Success)
                    {
                        //Console.WriteLine(match.Groups["A"].Value);
                        result.Add(match.Groups["A"].Value);
                        //Console.WriteLine(match.Groups["B"].Value);
                        result.Add(match.Groups["B"].Value);
                    }
                }
            }
            return result.ToArray();
        }
    }

    class Branch
    {
        public const char SPLITER = '┇';
        BindingList<Pair> pairs = new BindingList<Pair>();
        public void Clear()
        {
            pairs.Clear();
        }

        public void Push(string ver, string lot)
        {
            Pair p = new Pair();
            p.VER = ver;
            p.LOT = lot;
            pairs.Add(p);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (Pair i in pairs)
            {
                result += i.ToString() + SPLITER;
            }
            return result.TrimEnd(SPLITER);
        }
    }

    class Pair
    {
        string _VER;
        string _LOT;
        public string VER
        {
            get { return _VER; }
            set { _VER = value; }
        }
        public string LOT
        {
            get { return _LOT; }
            set { _LOT = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}┆{1}", _VER.Trim(), LOT.Trim());
        }
    }
}
