using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //   Token1.     Palabra reservada   int, float, double, ....
            //   Token2.     Identificador (variable)
            //   Token3.     Numero entero
            //   Token4.     Numero con punto decimal
            //   Token5.     Operador Aritmetico   +  -  *   /  ^   
            //   Token6.     Operador Relacional   >  >=  <   <=   !=   ==
            //   Token7.     Operador Logico   &&    ||   ~
            //   Token8.     Asignacion    =
            //   Token9.     Fin de instruccion     ;
            //   Token10.    Separador    ,
            //   Token11.    Parentesis   (   )
            //   Token12.    Corchetes    [   ]
            //   Token13.    Llaves       {   }
            //   Token14.    Cadena       "Hola"
            //   Token15.    Caracter     'z'
            //   Token16.    dos puntos  :
            //   Token17.    incremento   ++
            //   Token18.    Decremento   --
            //   Token19.    Operador aritmetivo inclusivo    +=  -=  *=  /=
            //   Token20.    Punto   .

            //Equipo   1    Tokens   3, 9, 11, 13, 18      Juan José Baños.        4:45.  PM

            //VARIABLES UTILIZADAS
           string patron2 = @"[a-zA-Z]\w*";      //   Identicador  (Variable
            string patron4 = @"[\+-]?\d+\.\d+";   //   Numero con punto decimal
            string patron3 = @"[\+-]?\d+";        //   numero entero
            string patron8 = "=";                 //   Asignacion  =
            string patron20 = ";";                //   Punto y coma
            string patron16 = ":";                 //dos puntos
            string patron10 = ",";                  //coma
            string patron17 = @"[\+]{2}\w*";       //incremento
            string patron18 = @"[\-]{2}\w*";       //decremento
            string patron21 = @"[\\.]\w*";       //punto
            string patron5 = @"[\+|\-|\*|\/|\^]\w*";       //Operador Aritmetico
            string patron11 = @"[\\(|\\)]\w*";       //Parentesis
            string patron12 = @"[\\[|\\\]]\w*";       //Corchetes
            string patron13 = @"[\\{|\\}]\w*";       //Llaves
            String patron6 = @"[a-zA-Z]\w*+(int|float)"; //operadores relacionales

            string patron = patron2 + "|" + patron4 + "|" + patron3 + "|" + patron8 + "|" + patron20 + "|" + patron10 + "|" + patron16 + "|" + patron17 + "|" + patron18 + "|" + patron21 + "|" + patron5 + "|" + patron11 + "|" + patron12 + "|" + patron13 + "|" + patron6;
            Regex exp2 = new Regex(patron2);
            Regex exp4 = new Regex(patron4);
            Regex exp3 = new Regex(patron3);
            Regex exp8 = new Regex(patron8);
            Regex exp20 = new Regex(patron20);
            Regex exp16 = new Regex(patron16);
            Regex exp10 = new Regex(patron10);
            Regex exp17 = new Regex(patron17);
            Regex exp18 = new Regex(patron18);
            Regex exp21 = new Regex(patron21);
            Regex exp5 = new Regex(patron5);
            Regex exp11 = new Regex(patron11);
            Regex exp12 = new Regex(patron12);
            Regex exp13 = new Regex(patron13);
            Regex exp6 = new Regex(patron6);


            string signo;
            string salida = string.Empty;
            string cadena = txtEntrada.Text;
            Match match = Regex.Match(cadena, patron);

            while (match.Success)
            {
                signo = "positivo";
                if (exp2.IsMatch(match.Value))
                    salida += "Token 2: Identificador (Variable) ---> " + match.Value + "\r\n";
                else if (exp4.IsMatch(match.Value))
                {
                    if (match.Value[0] == '-') signo = "negativo";
                    salida += "Token 4: Numero decimal " + signo + " ---> " + match.Value + "\r\n";
                }
                else if (exp3.IsMatch(match.Value))
                {
                    if (match.Value[0] == '-') signo = "negativo";
                    salida += "Token 3: Numero entero " + signo + " ---> " + match.Value + "\r\n";
                }
                else if (exp8.IsMatch(match.Value))
                    salida += "Token 8: Igualdad ---> " + match.Value + "\r\n";
                else if (exp20.IsMatch(match.Value))
                    salida += "Token 20: Punto y coma ---> " + match.Value + "\r\n";
                else if (exp16.IsMatch(match.Value))
                    salida += "Token 16:Dos puntos ---> " + match.Value + "\r\n";
                 else if (exp10.IsMatch(match.Value))
                    salida += "Token 10: Coma ---> " + match.Value + "\r\n";
                else if (exp17.IsMatch(match.Value))
                    salida += "Token 17: Incremento ---> " + match.Value + "\r\n";
                else if (exp18.IsMatch(match.Value))
                    salida += "Token 18: Decremento ---> " + match.Value + "\r\n";
                else if (exp21.IsMatch(match.Value))
                    salida += "Token 21: Punto ---> " + match.Value + "\r\n";
                else if (exp5.IsMatch(match.Value))
                    salida += "Token 5: Operador Aritmetico ---> " + match.Value + "\r\n";
                else if (exp11.IsMatch(match.Value))
                    salida += "Token 11: Parentesis ---> " + match.Value + "\r\n";
                else if (exp12.IsMatch(match.Value))
                    salida += "Token 12: Corchetes ---> " + match.Value + "\r\n";
                else if (exp13.IsMatch(match.Value))
                    salida += "Token 13: Llaves ---> " + match.Value + "\r\n";
                else if (exp6.IsMatch(match.Value))
                    salida += "Token 6: Operadores relacionales ---> " + match.Value + "\r\n";
                match = match.NextMatch();
            }
            txtSalida.Text = salida;
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtEntrada.Clear();
            txtSalida.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
