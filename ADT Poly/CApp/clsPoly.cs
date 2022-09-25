using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    public class clsPoly
    {   
        //1 er paso Atributos
        const int Max = 100;// nos da el limite de los Vectores
        private float[] VCoef; //este Vector contener solo los Coeficientes
        private int[] VExp; //este Vector contener solo los Exponentes
        public int nterm;// contador de terminos









        //2do paso Constructor
        public clsPoly()
        {
            VCoef = new float[Max];
            VExp = new int[Max];
            for(int i = 0; i < Max; i++)
            {
                VCoef[i] = 0;
                VExp[i] = 0;
            }

            this.nterm = 0;
        }
















        public clsPoly zero()
        {
            return new clsPoly();
        }

        public bool isZero()
        {
            return (nterm == 0);
        }















      
        public clsPoly attach(clsPoly p, float coef,int exp)
        {
               if((coef!=0)&& (exp >= 0))
               {
                if (p.VCoef[exp] == 0)
                {
                    p.nterm++;
                }
                p.VCoef[exp] = p.VCoef[exp] + coef;
                p.VExp[exp] = exp;
               }
            return p;
        }










        //Eliminar un monomio atraves del Exponente
        public clsPoly reem(clsPoly p,int exp)
        {

            if (exp >= 0)
            {
                if (p.VCoef[exp] != 0)
                {
                    p.nterm--;
                }
                p.VCoef[exp] = 0;
                p.VExp[exp] = 0;
            }
            return p;

        }








        public float Coef(int exp)
        {
            return VCoef[exp];
        }
        
        
        
        
        
















        
        //Retornar el grado mayor de un polinomio
        public int grado()
        {
            int Exp=0;
            for(int K = 0; K < Max; K++)
            {
                if (VExp[K] > 0)
                {
                    Exp = VExp[K];
                }
            }
            return Exp;

        }













        public clsPoly add( clsPoly P,clsPoly Q)
        {
            clsPoly C = new clsPoly();
            ///no estan Vacios los polinomios
            while((P.isZero()==true && Q.isZero()==true) == false)
            {
                if (P.grado() < Q.grado())
                {
                    C = attach(C, Q.Coef(Q.grado()), Q.grado());
                    Q = reem(Q, Q.grado());
                }
                if (P.grado() > Q.grado())
                {
                    C = attach(C, P.Coef(P.grado()), P.grado());
                    P = reem(P, P.grado());
                }


                if (P.grado() == Q.grado())
                {
                    C = attach(C, P.Coef(P.grado())+ Q.Coef(Q.grado()), P.grado());
                    P = reem(P, P.grado());
                    Q = reem(Q, Q.grado());
                }

            }

            return C;
        }






       // Smult(Poly, coef, exp)--> Poly      // Multiplicación por un monomio 
       
        public clsPoly Smult( clsPoly p, float coef,int exp)
        {
            clsPoly res = new clsPoly();
            for(int i = 0; i <= p.nterm; i++)
            {
                res = this.attach(res, p.VCoef[i] * coef, p.VExp[i] + exp);

            }
           return res;
        }
        public clsPoly SMult(clsPoly p, float coef, int exp)
        {
            clsPoly C = new clsPoly();
            while (p.isZero() == false)
            {
                C = attach(C, p.Coef(p.grado()) * coef, p.grado() + exp);

                p = reem(p, p.grado());
            }

            return C;

        }













        //Mult(Poly, Poly) --> Poly //Multiplicación de Polinomios

        public clsPoly Mult( clsPoly poliA,clsPoly poliB)
        {
            clsPoly C = new clsPoly();
            for(int i = 0; i <= poliA.nterm; i++)
            {
                for (int j = 0; j <= poliB.nterm; j++)
                {
                    C = attach(C, poliA.VCoef[i] * poliB.VCoef[j], poliA.VExp[i] + poliB.VExp[j]);

                }
            }

            return C;
        }



















    }
}
