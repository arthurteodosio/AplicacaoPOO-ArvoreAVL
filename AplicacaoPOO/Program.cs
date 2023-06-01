using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoPOO
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
                info = 0;
                fb = 0;
            }
            public void Inserir(int n, ref No raiz)
            {
                No temp, subNo, pai;
                this.info = n;
                if (raiz == null)
                {
                    raiz = this;
                    Console.WriteLine($"O número {n} é a raiz.");
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
                                Console.WriteLine($"Número {n} inserido a esquerda de {subNo.info}");
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
                                Console.WriteLine($"Número {n} inserido a direita de {subNo.info}");
                            }
                        }

                      if (contador > 0)
                        {
                            if (pai.fb == -2 && (Math.Abs(subNo.fb) != 2))
                            {
                                Console.WriteLine($"fb de {pai.info} igual a {pai.fb}");
                                if (subNo.fb < 0)
                                {
                                    Console.WriteLine("Rotacionando para a direita");
                                    raiz.rotacionarArvoreDireita(ref pai, ref subNo);
                                }
                            }
                            else if (pai.fb == 2 && (Math.Abs(subNo.fb) != 2))
                            {
                                Console.WriteLine($"fb de {pai.info} igual a {pai.fb}");
                                if (subNo.fb > 0)
                                {
                                    Console.WriteLine("Rotacionando para a esquerda");
                                    raiz.rotacionarArvoreEsquerda(ref pai, ref subNo);
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
                Console.WriteLine($"Fb de {this.info} é igual a {this.fb}");

                if (this.sae != null) (this.sae).mostrarFb();
                if (this.sad != null) (this.sad).mostrarFb();
            }
            public int calcularFb()
            {
                int fbe = 0;
                int fbd = 0;

                if (this.sae != null) fbe = (this.sae).calcularFb() + 1;
                if (this.sad != null) fbd = (this.sad).calcularFb() + 1;

                this.fb = fbe - fbd;

                Console.WriteLine($"Fb de {this.info} = {this.fb}");

                return Math.Max(fbe, fbd);
            }
            public void rotacionarArvoreEsquerda()
            {
                (pai.info, subno.info) = (subno.info, pai.info);
                (pai.sad, subno.sad) = (subno.sad, pai.sad);
                (pai.sae, subno.sae) = (subno.sae, pai.sae);
                (pai.fb, subno.fb) = (subno.fb, pai.fb);

                subno.sad = pai.sae;
                pai.sae = subno;
            }
            
             public void rotacionarArvoreDireita()
            {
                (pai.info, subno.info) = (subno.info, pai.info);
                (pai.sad, subno.sad) = (subno.sad, pai.sad);
                (pai.sae, subno.sae) = (subno.sae, pai.sae);
                (pai.fb, subno.fb) = (subno.fb, pai.fb);

                subno.sae = pai.sad;
                pai.sad = subno;
             }
            
            public void removerNo(int n, ref No raiz)
            {
                if (this == raiz && raiz.info == n)
                {
                    if (this.sae == null && this.sad == null)
                    {
                        raiz = null;
                        Console.WriteLine("Árvore removida.");
                    }
                    else if (this.sad == null || this.sae == null)
                    {
                        if (this.sad != null)
                        {
                            raiz = this.sad;
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sad.info} (Nova raiz).");
                        }
                        else
                        {
                            raiz = this.sae;
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sae.info} (Nova raiz).");
                        }
                    }
                    else
                    {
                        No temp = this.sae;
                        if (temp.sad == null)
                        {
                            temp.sad = this.sad;
                            raiz = temp;
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info} (Nova raiz).");
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
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info} (Nova raiz).");
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
                            Console.WriteLine($"Número {n} (Sem filhos) removido.");
                        }
                        else
                        {
                            Console.WriteLine($"Número {n} não foi encontrado.");
                        }
                    }
                    else if ((this.sad).info == n && (((this.sad).sad) ==
                    null || ((this.sad).sae) == null))
                    {
                        if (((this.sad).sad) != null)
                        {
                            this.sad = ((this.sad).sad);
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sad.info}.");
                        }
                        else
                        {
                            this.sad = ((this.sad).sae);
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sad.info}.");
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
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info}.");
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
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info}.");
                        }
                    }
                    else
                    {
                        (this.sad).removerNo(n, ref raiz);
                    }
                }
                else if (n < this.info)
                {
                    if ((this.sae).sae == null && (this.sae).sad == null)
                    {
                        if (this.sae.info == n)
                        {
                            this.sae = null;
                            Console.WriteLine($"Número {n} (Sem filhos) removido.");
                        }
                        else
                        {
                            Console.WriteLine($"Número {n} não foi encontrado.");
                        }
                    }
                    else if ((this.sae).info == n && (((this.sae).sad) ==
                    null || ((this.sae).sae) == null))
                    {
                        if (((this.sae).sad) != null)
                        {
                            this.sae = ((this.sae).sad);
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sae.info}.");
                        }
                        else
                        {
                            this.sae = ((this.sae).sae);
                            Console.WriteLine($"Número {n} removido (Um filho) foi substituído por {this.sae.info}.");
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
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info}.");
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
                            Console.WriteLine($"Número {n} removido (Dois filhos) foi substituído por {temp.info}.");
                        }
                    }
                    else
                    {
                        (this.sae).removerNo(n, ref raiz);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            No raiz = null;
            int response = 0;
            int[] arvoreInicial = { 14, 8, 18, 5, 10, 1 };
            foreach (int i in arvoreInicial)
            {
                No temp = new No();
                temp.Inserir(i, ref raiz);
            }
            while (response != 5)
            {
                Console.Clear();
                Console.WriteLine("1 - Inserir Nó");
                Console.WriteLine("2 - Mostrar Árvore");
                Console.WriteLine("3 - Remover Nó");
                Console.WriteLine("4 - Calcular Fb");
                Console.WriteLine("5 - Sair");
                response = int.Parse(Console.ReadLine());
                if (response == 1)
                {
                    Console.Clear();
                    int n = int.Parse(Console.ReadLine());
                    No temp = new No();
                    temp.Inserir(n, ref raiz);
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
                        Console.WriteLine("Árvore vazia");
                    }
                    Console.ReadKey();
                }
                else if (response == 3)
                {
                    Console.Clear();
                    int n = int.Parse(Console.ReadLine());
                    if (raiz != null)
                    {
                        raiz.removerNo(n, ref raiz);
                    }
                    else
                    {
                        Console.WriteLine("Árvore vazia");
                    }
                    Console.ReadKey();
                }
                else if (response == 4)
                {
                    Console.Clear();
                    if (raiz != null)
                    {
                        raiz.calcularFb();
                    }
                    else
                    {
                        Console.WriteLine("Árvore vazia");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
