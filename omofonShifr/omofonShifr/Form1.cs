using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace omofonShifr
{
    //Реализовать программное приложение для шифрования и расшифровки текста шифром "Омофонический шифр (простой)"
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        Dictionary<string, string> alf = new Dictionary<string, string>(2)
        {
            {"Кирилица","rusAlf"},
            {"Латиница","anglAfl"}
        };

        Dictionary<string, string[]> rusAlf = new Dictionary<string, string[]>(34)
        {
            {"а",  new string[] { "14", "16", "24", "44", "46", "55", "57", "64" }},
            {"б",  new string[] { "48", "81" }},
            {"в",  new string[] { "13", "41", "62" }},
            {"г",  new string[] { "01", "03", "45", "79" }},
            {"д",  new string[] { "09", "12", "33", "53"}},
            {"е",  new string[] { "10", "31" }},
            {"ё",  new string[] { "06", "25" }},
            {"ж",  new string[] { "50", "56", "65" }},
            {"з",  new string[] { "93" }},
            {"и",  new string[] { "32", "70", "73", "83", "88"}},
            {"й",  new string[] { "04" }},
            {"к",  new string[] { "26", "37", "51", "84" }},
            {"л",  new string[] { "22", "27" }},
            {"м",  new string[] { "18", "58", "59", "66", "91" }},
            {"н",  new string[] { "00", "05", "07", "54", "72", "90"}},
            {"о",  new string[] { "38", "95", "92", "68", "67", "78", "74" }},
            {"п",  new string[] { "69", "75", "85" }},
            {"р",  new string[] { "29", "35", "40", "77", "80" }},
            {"с",  new string[] { "11", "19", "36", "76", "96", "08" }},
            {"т",  new string[] { "17", "20", "30", "42", "49"}},
            {"у",  new string[] { "82", "47","61", "63"}},
            {"ф",  new string[] { "60", "89" }},
            {"х",  new string[] { "28" }},
            {"ц",  new string[] { "21", "52" }},
            {"ч",  new string[] { "86", "71" }},
            {"ш",  new string[] { "02" }},
            {"щ",  new string[] { "97" }},
            {"ь",  new string[] { "15" }},
            {"ы",  new string[] { "98" }},
            {"ъ",  new string[] { "94" }},
            {"э",  new string[] { "34" }},
            {"ю",  new string[] { "87" }},
            {"я",  new string[] { "23", "39" }},
            {" ",  new string[] { "99" }},
        };

        Dictionary<string, string[]> anglAfl = new Dictionary<string, string[]>(34)
        {
            {"a",  new string[] { "09", "12", "33", "47", "53", "67", "78", "92","43" } },
            {"b",  new string[] { "48", "81" }},
            {"c",  new string[] { "13", "41", "62" }},
            {"d",  new string[] { "01", "03", "45", "79" }},
            {"e",  new string[] { "14", "16", "24", "44", "46", "55", "57", "64", "74", "82", "87", "98" }},
            {"f",  new string[] { "10", "31" }},
            {"g",  new string[] { "06", "25" }},
            {"h",  new string[] { "23", "39", "50", "56", "65", "68" }},
            {"i",  new string[] { "32", "70", "73", "83", "88", "93" }},
            {"j",  new string[] { "15" }},
            {"k",  new string[] { "04" }},
            {"l",  new string[] { "26", "37", "51", "84" }},
            {"m",  new string[] { "22", "27" }},
            {"n",  new string[] { "18", "58", "59", "66", "71", "91" }},
            {"o",  new string[] { "00", "05", "07", "54", "72", "90",}},
            {"p",  new string[] { "38", "95" }},
            {"q",  new string[] { "94" }},
            {"r",  new string[] { "29", "35", "40", "42", "77", "80" }},
            {"s",  new string[] { "11", "19", "36", "76", "86", "96" }},
            {"t",  new string[] { "17", "20", "30", "49", "69", "75", "85", "97" }},
            {"u",  new string[] { "08", "61", "63" }},
            {"v",  new string[] { "34" }},
            {"w",  new string[] { "60", "89" }},
            {"x",  new string[] { "28" }},
            {"y",  new string[] { "21", "52" }},
            {"z",  new string[] { "02" }},
            {" ",  new string[] { "99" }},
        };

        Dictionary<string, string[]> decodAfl = new Dictionary<string, string[]>(34)
        {
            {"00",  new string[] { "н","o" }},
            {"01",  new string[] { "г","d" }},
            {"02",  new string[] { "ш","z" }},
            {"03",  new string[] { "г","d" }},
            {"04",  new string[] { "й","k" }},
            {"05",  new string[] { "н","o" }},
            {"06",  new string[] { "ё","g" }},
            {"07",  new string[] { "н","o" }},
            {"08",  new string[] { "с","u" }},
            {"09",  new string[] { "д","a" }},
            {"10",  new string[] { "е","f" }},
            {"11",  new string[] { "с","s" }},
            {"12",  new string[] { "д","a" }},
            {"13",  new string[] { "в","c" }},
            {"14",  new string[] { "а","e" }},
            {"15",  new string[] { "ь","j" }},
            {"16",  new string[] { "а","e" }},
            {"17",  new string[] { "т","t" }},
            {"18",  new string[] { "м","n" }},
            {"19",  new string[] { "с","s" }},
            {"20",  new string[] { "т","t" }},
            {"21",  new string[] { "ц","y" }},
            {"22",  new string[] { "л","m" }},
            {"23",  new string[] { "я","h" }},
            {"24",  new string[] { "а","e" }},
            {"25",  new string[] { "ё","g" }},
            {"26",  new string[] { "к","l" }},
            {"27",  new string[] { "л","m" }},
            {"28",  new string[] { "х","x" }},
            {"29",  new string[] { "р","r" }},
            {"30",  new string[] { "т","t" }},
            {"31",  new string[] { "е","f" }},
            {"32",  new string[] { "и","i" }},
            {"33",  new string[] { "д","a" }},
            {"34",  new string[] { "э","v" }},
            {"35",  new string[] { "р","r" }},
            {"36",  new string[] { "с","s" }},
            {"37",  new string[] { "к","l" }},
            {"38",  new string[] { "о","p" }},
            {"39",  new string[] { "я","h" }},
            {"40",  new string[] { "р","r" }},
            {"41",  new string[] { "в","c" }},
            {"42",  new string[] { "т","r" }},
            {"43",  new string[] { "а","a" }},
            {"44",  new string[] { "а","e" }},
            {"45",  new string[] { "г","d" }},
            {"46",  new string[] { "а","e" }},
            {"47",  new string[] { "у","a" }},
            {"48",  new string[] { "б","b" }},
            {"49",  new string[] { "т","t" }},
            {"50",  new string[] { "ж","h" }},
            {"51",  new string[] { "к","l" }},
            {"52",  new string[] { "ц","y" }},
            {"53",  new string[] { "д","a" }},
            {"54",  new string[] { "н","o" }},
            {"55",  new string[] { "а","e" }},
            {"56",  new string[] { "ж","h" }},
            {"57",  new string[] { "а","e" }},
            {"58",  new string[] { "м","n" }},
            {"59",  new string[] { "м","n" }},
            {"60",  new string[] { "ф","w" }},
            {"61",  new string[] { "у","u" }},
            {"62",  new string[] { "в","c" }},
            {"63",  new string[] { "у","u" }},
            {"64",  new string[] { "а","e" }},
            {"65",  new string[] { "ж","h" }},
            {"66",  new string[] { "м","n" }},
            {"67",  new string[] { "о","a" }},
            {"68",  new string[] { "о","h" }},
            {"69",  new string[] { "п","t" }},
            {"70",  new string[] { "и","i" }},
            {"71",  new string[] { "ч","n" }},
            {"72",  new string[] { "н","o" }},
            {"73",  new string[] { "и","i" }},
            {"74",  new string[] { "о","e" }},
            {"75",  new string[] { "п","t" }},
            {"76",  new string[] { "с","s" }},
            {"77",  new string[] { "р","r" }},
            {"78",  new string[] { "о","a" }},
            {"79",  new string[] { "г","d" }},
            {"80",  new string[] { "р","r" }},
            {"81",  new string[] { "б","b" }},
            {"82",  new string[] { "у","e" }},
            {"83",  new string[] { "и","i" }},
            {"84",  new string[] { "к","l" }},
            {"85",  new string[] { "п","t" }},
            {"86",  new string[] { "ч","s" }},
            {"87",  new string[] { "ю","e" }},
            {"88",  new string[] { "и","i" }},
            {"89",  new string[] { "ф","w" }},
            {"90",  new string[] { "н","o" }},
            {"91",  new string[] { "м","n" }},
            {"92",  new string[] { "о","a" }},
            {"93",  new string[] { "з","i" }},
            {"94",  new string[] { "ъ","q" }},
            {"95",  new string[] { "о","p" }},
            {"96",  new string[] { "с","s" }},
            {"97",  new string[] { "щ","t" }},
            {"98",  new string[] { "ы","e" }},
            {"99",  new string[] { " "," " }},
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //comboBox1.DataSource = new BindingSource(alf, );
           //comboBox1.DisplayMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;

            if ((textBox1.Text.ToString() != "") && (comboBox1.SelectedItem != null ))
            {
                string text = textBox1.Text.ToString().ToLowerInvariant();
                textBox2.Text = shifrator(text, comboBox1.SelectedItem.ToString());
            }
            else 
            {
                label3.Visible = (textBox1.Text.ToString() == "" ? true : false);
                label4.Visible = (comboBox1.SelectedItem == null ? true : false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;

            if ((textBox1.Text.ToString() != "") && (comboBox1.SelectedItem != null))
            {
                string text = textBox1.Text.ToString().ToLowerInvariant();
                textBox2.Text = defrator(text, comboBox1.SelectedItem.ToString());
            }
            else
            {
                label3.Visible = (textBox1.Text.ToString() == "" ? true : false);
                label4.Visible = (comboBox1.SelectedItem == null ? true : false);
            }
        }

        private string shifrator(string text, string alfavit)
        {
            string result = "";
            if (alfavit == "Латиница")
            {
                foreach (char ch in text)
                {
                    try
                    {
                        string[] b = anglAfl[ch.ToString()];
                        result += b[rnd.Next(0, b.Length)].ToString();
                    }
                    catch
                    {
                        result += ch.ToString();
                    };
                };
            }
            else
            {
                foreach (char ch in text)
                {
                    try
                    {
                        string[] b = rusAlf[ch.ToString()];
                        result += b[rnd.Next(0, b.Length)].ToString();
                    }
                    catch 
                    {
                        result += ch.ToString();
                    };
                };
            }
            
            return result;
        }

        private string defrator(string text, string alfavit)
        {
            string result = "";

            if (alfavit == "Латиница")
            {
                for (int i = 0; i < text.Length; )
                {
                    try
                    {
                        string wor = text[i].ToString() + text[i + 1].ToString();
                        string[] b = decodAfl[wor.ToString()];
                        result += b[1].ToString();
                        i += 2;
                    }
                    catch
                    {
                        result += text[i].ToString();
                        ++i;
                    };
                }
            }
            else
            {
                for (int i = 0; i < text.Length; )
                {
                    try
                    {
                        string wor = text[i].ToString() + text[i + 1].ToString();
                        string[] b = decodAfl[wor.ToString()];
                        result += b[0].ToString();
                        i += 2;
                    }
                    catch
                    {
                        result += text[i].ToString();
                        ++i;
                    };
                }
            }

            return result;
        }

        private void analizis ()
        {
            Dictionary<string, int> schetAlf = new Dictionary<string, int>();
            string text = textBox1.Text;
            foreach (char ch in text)
            {
                if (schetAlf.ContainsKey(ch.ToString()) != true)
                {
                    schetAlf.Add(ch.ToString(), 1); 
                }
                else
                {
                    schetAlf[ch.ToString()] += 1;
                }
            };

            string res = "Частотная характеристика текста: " + System.Environment.NewLine;
            foreach (var item in schetAlf)
            {
                double value = Convert.ToDouble(item.Value);
                double length = Convert.ToDouble(text.Length);
                res += (item.Key + " - " + Math.Round((value / length * 100.0),2) + " %" + System.Environment.NewLine);
            };

            res += analizisBi();
            res += analizisTre();
            textBox3.Text = res;
        }

        private string analizisBi ()
        {
            Dictionary<string, int> schetBiAlf = new Dictionary<string, int>();
            string text = textBox1.Text;

            for (int i = 0; i < text.Length - 1; i += 1)
            {
                string wor = text[i].ToString() + text[i + 1].ToString();

                if (schetBiAlf.ContainsKey(wor) != true)
                {
                    schetBiAlf.Add(wor, 1);
                }
                else
                {
                    schetBiAlf[wor] += 1;
                }
            };

            string res = "";
            res += System.Environment.NewLine + "Биграмм: " + System.Environment.NewLine;
            foreach (var item in schetBiAlf)
            {
                res += (item.Key + " - " + item.Value + System.Environment.NewLine);
            };

            return res;
        }

        private string analizisTre()
        {
            Dictionary<string, int> schetTreAlf = new Dictionary<string, int>();
            string text = textBox1.Text;
            for (int i = 0; i < text.Length - 2; i += 1)
            {
                string wor = text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();

                if (schetTreAlf.ContainsKey(wor) != true)
                {
                    schetTreAlf.Add(wor, 1);
                }
                else
                {
                    schetTreAlf[wor] += 1;
                };
            };

            string res = "";
            res += System.Environment.NewLine + "Триграмм: " + System.Environment.NewLine;
            foreach (var item in schetTreAlf)
            {
                res += (item.Key + " - " + item.Value + System.Environment.NewLine);
            };

            return res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            analizis();
        }

    }
}
