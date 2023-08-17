using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArvoreBinaria
{
    internal class Program
    {
        public class No
        {
            public No sae;
            public No sad;
            public int info;
            public int fb;
            public No()
            {
                sae = null;
                sad = null;
                fb = 0;
                info = 0;
            }
            public void adicionar(int n, ref No raiz)
            {
                No temp, subNo, pai;
                this.info = n;
                if (raiz == null)
                {
                    raiz = this;
                    Console.WriteLine($"O numero {n} e a raiz!");
                }
                else
                {
                    int contador = 0;
                    temp = raiz;
                    pai = temp;
                    while (temp != null)
                    {
                        subNo = temp;
                        if (n <= temp.info)
                        {
                            temp.fb -= 1;
                            temp = temp.sae;
                            if (temp == null)
                            {
                                subNo.sae = this;
                                Console.WriteLine($"Numero {n} adicionado a esquerda de { subNo.info} !");
                                pai.calcularFb();
                            }
                        }
                        else
                        {
                            temp.fb += 1;
                            temp = temp.sad;
                            if (temp == null)
                            {
                                subNo.sad = this;
                                pai.calcularFb();
                                Console.WriteLine($"Numero {n} adicionado a direita de { subNo.info} !");
                            }
                        }

                        if (contador > 0)
                        {
                            // se fb for igual ou menor que -2
                            if (pai.fb == -2 && (Math.Abs(subNo.fb) != 2))
                            {
                                Console.WriteLine($"fb de {pai.info} igual a {pai.fb}");
                                if (subNo.fb < 0)
                                {
                                    Console.WriteLine("Rodnado para a direita");
                                    raiz.rodarArvoreDireita(ref pai, ref subNo);
                                }
                            }
                            else if (pai.fb == 2 && (Math.Abs(subNo.fb) != 2))
                            {
                                Console.WriteLine($"fb de {pai.info} igual a {pai.fb}");
                                if (subNo.fb > 0)
                                {
                                    Console.WriteLine("Rodando para a esquerda");
                                    raiz.rodarArvoreEsquerda(ref pai, ref subNo);
                                }
                            }
                            pai = subNo;
                        }
                        else contador++;
                    }
                }
            }
            public void mostrarArvore()
            {
                Console.WriteLine(this.info);

                if (this.sae != null) (this.sae).mostrarArvore();
                if (this.sad != null) (this.sad).mostrarArvore();
            }
            public void mostrarFb()
            {
                Console.WriteLine($"fb de {this.info} e igual a {this.fb}");

                if (this.sae != null) (this.sae).mostrarFb();
                if (this.sad != null) (this.sad).mostrarFb();
            }
            public int calcularFb()
            {
                int fbe = 0;
                int fbd = 0;

                if (this.sae != null) fbe = (this.sae).calcularFb() + 1;
                if (this.sad != null) fbd = (this.sad).calcularFb() + 1;

                this.fb = fbd - fbe;

                return Math.Max(fbe, fbd);
            }
            public void rodarArvoreEsquerda(ref No pai, ref No subno)
            {
                (pai.info, subno.info) = (subno.info, pai.info);
                (pai.sad, subno.sad) = (subno.sad, pai.sad);
                (pai.sae, subno.sae) = (subno.sae, pai.sae);
                (pai.fb, subno.fb) = (subno.fb, pai.fb);

                subno.sad = pai.sae;
                pai.sae = subno;
            }
            public void rodarArvoreDireita(ref No pai, ref No subno)
            {
                (pai.info, subno.info) = (subno.info, pai.info);
                (pai.sad, subno.sad) = (subno.sad, pai.sad);
                (pai.sae, subno.sae) = (subno.sae, pai.sae);
                (pai.fb, subno.fb) = (subno.fb, pai.fb);

                subno.sae = pai.sad;
                pai.sad = subno;
            }
            public void deletarNo(int n, ref No raiz)
            {
                if (this == raiz && raiz.info == n)
                {
                    if (this.sae == null && this.sad == null)
                    {
                        raiz = null;
                        Console.WriteLine("Arvore apagada!");
                    }
                    else if (this.sad == null || this.sae == null)
                    {
                        if (this.sad != null)
                        {
                            raiz = this.sad;
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sad.info} (Nova raiz)!");
                        }
                        else
                        {
                            raiz = this.sae;
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sae.info} (Nova raiz)!");
                        }
                    }
                    else
                    {
                        No temp = this.sae;
                        if (temp.sad == null)
                        {
                            temp.sad = this.sad;
                            raiz = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} (Nova raiz)!");
}
                        else
                        {
                            No subNo = temp;
                            while (temp.sad != null)
                            {
                                subNo = temp;
                                temp = temp.sad;
                            }
                            subNo.sad = null;
                            temp.sae = this.sae;
                            temp.sad = this.sad;
                            raiz = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} (Nova raiz)!");
                        }
                    }
                }
                else if (n > this.info)
                {
                    if ((this.sad).sae == null && (this.sad).sad == null)
                    {
                        if (this.sad.info == n)
                        {
                            this.sad = null;
                            Console.WriteLine($"Numero {n} (Sem filhos) deletado!");
                        }
                        else
                        {
                            Console.WriteLine($"Numero {n} nao foi encontrado!");
                        }
                    }
                    else if ((this.sad).info == n && (((this.sad).sad) ==
                    null || ((this.sad).sae) == null))
                    {
                        if (((this.sad).sad) != null)
                        {
                            this.sad = ((this.sad).sad);
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sad.info} !");
                        }
                        else
                        {
                            this.sad = ((this.sad).sae);
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sad.info} !");
}
                    }
                    else if ((this.sad).info == n && (((this.sad).sad) !=
                    null && ((this.sad).sae) != null))
                    {
                        No temp = (this.sad).sae;
                        if (temp.sad == null)
                        {
                            temp.sad = (this.sad).sad;
                            this.sad = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} !");
                        }
                        else
                        {
                            No subNo = temp;
                            while (temp.sad != null)
                            {
                                subNo = temp;
                                temp = temp.sad;
                            }
                            subNo.sad = null;
                            temp.sae = (this.sad).sae;
                            temp.sad = (this.sad).sad;
                            this.sad = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} !");
                        }
                    }
                    else
                    {
                        (this.sad).deletarNo(n, ref raiz);
                    }
                }
                else if (n < this.info)
                {
                    if ((this.sae).sae == null && (this.sae).sad == null)
                    {
                        if (this.sae.info == n)
                        {
                            this.sae = null;
                            Console.WriteLine($"Numero {n} (Sem filhos) deletado!");
                        }
                        else
                        {
                            Console.WriteLine($"Numero {n} nao foi encontrado!");
}
                    }
                    else if ((this.sae).info == n && (((this.sae).sad) ==
                    null || ((this.sae).sae) == null))
                    {
                        if (((this.sae).sad) != null)
                        {
                            this.sae = ((this.sae).sad);
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sae.info} !");
                        }
                        else
                        {
                            this.sae = ((this.sae).sae);
                            Console.WriteLine($"Numero {n} deletado (Um filho) foi substituido por { this.sae.info} !");
                        }
                    }
                    else if ((this.sae).info == n && (((this.sae).sad) !=
                    null && ((this.sae).sae) != null))
                    {
                        No temp = (this.sae).sae;
                        if (temp.sad == null)
                        {
                            temp.sad = (this.sae).sad;
                            this.sae = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} !");
                        }
                        else
                        {
                            No subNo = temp;
                            while (temp.sad != null)
                            {
                                subNo = temp;
                                temp = temp.sad;
                            }
                            subNo.sad = null;
                            temp.sae = (this.sae).sae;
                            temp.sad = (this.sae).sad;
                            this.sae = temp;
                            Console.WriteLine($"Numero {n} deletado (Dois filhos) foi substituido por { temp.info} !");
                        }
                    }
                    else
                    {
                        (this.sae).deletarNo(n, ref raiz);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            No raiz = null;
            int response = 0;
            //int[] arvoreInicial = { 15, 10, 20, 17, 16, 18, 21, 12, 11, 5, 8, 9 };
            int[] arvoreInicial = { 5, 4, 3, 2, 1 };
            foreach (int i in arvoreInicial)
            {
                No temp = new No();
                temp.adicionar(i, ref raiz);
                Console.ReadKey();
            }
            while (response != 5)
            {
                Console.Clear();
                Console.WriteLine("1 - Adicionar No");
                Console.WriteLine("2 - Mostrar arvore");
                Console.WriteLine("3 - Deletear No");
                Console.WriteLine("4 - Calcular FB");
                Console.WriteLine("5 - Sair");
                response = int.Parse(Console.ReadLine());
                if (response == 1)
                {
                    Console.Clear();
                    int n = int.Parse(Console.ReadLine());
                    No temp = new No();
                    temp.adicionar(n, ref raiz);
                    Console.ReadKey();
                }
                else if (response == 2)
                {
                    Console.Clear();
                    if (raiz != null)
                    {
                        raiz.mostrarArvore();
                    }
                    else
                    {
                        Console.WriteLine("Arvore vazia");
                    }
                    Console.ReadKey();
                }
                else if (response == 3)
                {
                    Console.Clear();
                    int n = int.Parse(Console.ReadLine());
                    if (raiz != null)
                    {
                        raiz.deletarNo(n, ref raiz);
                    }
                    else
                    {
                        Console.WriteLine("Arvore vazia");
                    }
                    Console.ReadKey();
                }
                else if (response == 4)
                {
                    Console.Clear();
                    if (raiz != null)
                    {
                        raiz.mostrarFb();
                    }
                    else
                    {
                        Console.WriteLine("Arvore vazia");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
