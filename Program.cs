using System;

namespace Orientacao.Evento.Carro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio poliformismo, classe abstrata, Evento");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Carangas Ponto.com");
            Console.WriteLine("===================");
            Console.WriteLine("");
            Console.WriteLine("");

            var car = new Vistoria();

            car.Id = 1;
            car.Modelo = "SUV";
            car.Marca = "GM";
            car.Ano = 1961;
            car.Potencia = 20;
            car.Estrutura = "Detalhes na Lataria";
            car.DetalhesVistoria = "Sem para-choque";
            
            Console.WriteLine("");
            Console.WriteLine(car.Id.ToString());
            Console.WriteLine(car.Modelo.ToString());
            Console.WriteLine(car.Marca.ToString());
            Console.WriteLine(car.Ano.ToString());
            Console.WriteLine(car.Potencia.ToString());
            Console.WriteLine(car.Estrutura.ToString());
            Console.WriteLine(car.DetalhesVistoria.ToString());
            Console.WriteLine("RESULTADO : ");
            car.Emplacar();
            Console.WriteLine("=====================================");

            Console.WriteLine("");
            Console.WriteLine("");
            
            var carReforma = new Reforma();

            //exemplo.MeuEvento += MeuManipuladorDeEvent

            carReforma.ReformaEvento += AoReformaEvento;

            carReforma.Id = 2;
            carReforma.Modelo = "PASSEIO";
            carReforma.Marca = "CHEVROLET";
            carReforma.Ano = 2010;
            carReforma.Potencia = 50;
            carReforma.Pintura = false;
            carReforma.Motor = false;

            Console.WriteLine(carReforma.Id.ToString());
            Console.WriteLine(carReforma.Modelo);
            Console.WriteLine(carReforma.Marca);
            Console.WriteLine(carReforma.Ano);
            Console.WriteLine(carReforma.Potencia);
            Console.WriteLine(carReforma.Pintura);
            Console.WriteLine(carReforma.Motor);
            Console.WriteLine("RESULTADOS :");
            carReforma.Emplacar(); 
            carReforma.Libera();

            
        }

        static void AoReformaEvento(object sender, EventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("Carro sem condições de Reforma !!!!!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");


        }

    }

    public abstract class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public int Potencia { get; set; }

        public Carro()
        {
            Ano = 0;
            Potencia = 0;
        }

        public void Emplacar()
        {
            Console.Write("Esse carro está em situação regular no DETRAN");
        }

    }

    public class Vistoria : Carro
    {
        public string Estrutura { get; set; }
        public string DetalhesVistoria { get; set; }


        public void Emplacar()
        {
            if (this.Ano < 1993)
            {
                Console.WriteLine("Esse carro pode ter placa preta !");
            }
            else
            {
                Console.WriteLine("Só pode colocar placa do mercoSul");
            }
        }

    }
    public class Reforma : Carro
    {
        public event EventHandler ReformaEvento;
        public bool Pintura { get; set; }
        public bool Motor { get; set; }

        public Reforma()
        {
            Motor = true;
            Pintura = true;
        }

       public void Libera()
        {

            if (!Motor && !Pintura)
            {
                OnReformaEvento(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("Carro liberado para reforma !");
            }
        }
            

        public void Emplacar()
        {
            if (this.Ano < 1993)
            {
                Console.WriteLine("Esse carro pode ter placa preta !");
            }
            else
            {
                Console.WriteLine("Só pode colocar placa do mercoSul");
            }
        }

        protected virtual void OnReformaEvento(EventArgs e)
        {
            EventHandler handler = ReformaEvento;
            handler?.Invoke(this, e);
        }

    }


}