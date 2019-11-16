using Projeto.Repositorios.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Entidades
{
    public interface ISimulacaoPeriodoAcademico
    {
        void    Simular();
        string  ObterSituacaoPeriodoAcademicoAluno(int idAluno);
        decimal CalcularMediaPonderada(decimal pv1, decimal pv2, decimal pv3, decimal p1, decimal p2, decimal p3);
        decimal CalcularMediaAritmetica(decimal mediaPonderada, decimal provaFinal);
        bool    VerificaSeFazProvaFinal(decimal mediaPonderada);
        string  ObterSituacaoMateria(decimal mediaPonderada, decimal mediaAritmetica);
    }

    public class SimulacaoPeriodoAcademico : ISimulacaoPeriodoAcademico
    {
        public decimal CalcularMediaPonderada(
            decimal pv1, decimal pv2, decimal pv3, decimal p1, decimal p2, decimal p3)
        {
            return Math.Round(((pv1 * p1) + (pv2 * p2) + (pv3 * p3)) / (p1 + p2 + p3), 1);
        }

        public decimal CalcularMediaAritmetica(decimal mediaPonderada, decimal provaFinal)
        {
            return Math.Round((mediaPonderada + provaFinal) / 2, 1);
        }

        public string ObterSituacaoPeriodoAcademicoAluno(int idAluno)
        {
            MateriaRepository      materiaRep              = new MateriaRepository();
            MateriaAlunoRepository materiaAlunoRep         = new MateriaAlunoRepository();
            string                 situacao                = string.Empty;
            int                    quantMateriasAprovadas  = 0;
            int                    quantMateriasReprovadas = 0;
            int                    quantMaterias           = 0;
            
            foreach (MateriaAluno materiaAluno in materiaAlunoRep.FindAllByIdAluno(idAluno))
            {
                quantMaterias++;

                Materia materia = materiaRep.FindById(materiaAluno.IdMateria);

                decimal mediaPonderada = CalcularMediaPonderada(materiaAluno.NotaProva1, 
                    materiaAluno.NotaProva2, materiaAluno.NotaProva3, materia.PesoProva1, 
                    materia.PesoProva2, materia.PesoProva3);

                if (mediaPonderada >= 6.0M)
                {
                    quantMateriasAprovadas++;
                }
                else if (mediaPonderada <= 4.0M)
                {
                    quantMateriasReprovadas++;
                }
                else
                {
                    //calcula a média aritmética entre a média ponderada e a prova final
                    decimal mediaAritmetica = CalcularMediaAritmetica(mediaPonderada, materiaAluno.NotaProvaFinal);

                    if (mediaAritmetica >= 5.0M)
                    {
                       quantMateriasAprovadas++;
                    }
                    else
                    {
                       quantMateriasReprovadas++;
                    }
                }
            }


            if (quantMateriasAprovadas >= quantMaterias * 0.6)
            {
                situacao = "APROVADO";
            }
            else
            {
                situacao = "REPROVADO";
            }


            return situacao;
        }

        public void Simular()
        {
            MateriaRepository      materiaRep      = new MateriaRepository();
            AlunoRepository        alunoRep        = new AlunoRepository();
            MateriaAlunoRepository materiaAlunoRep = new MateriaAlunoRepository();
            Random                 random          = new Random();

            //Exclui a simulação existente para incluir a nova(1(uma) sumulação por vez)
            foreach (MateriaAluno ma in materiaAlunoRep.FindAll())
            {
                materiaAlunoRep.Delete(ma);
            }

            //Faz a nova simulação
            foreach (Materia materia in materiaRep.FindAll())
            {
                foreach (Aluno aluno in alunoRep.FindAll())
                {
                    MateriaAluno ma = new MateriaAluno();
                    ma.IdMateria    = materia.IdMateria;
                    ma.IdAluno      = aluno.IdAluno;

                    ma.NotaProva1 = Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 1);
                    ma.NotaProva2 = Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 1);
                    ma.NotaProva3 = Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 1);

                    //calcula a média ponderada das notas para saber se precisa 
                    //simular a prova final
                    decimal mediaPonderada = CalcularMediaPonderada(
                        ma.NotaProva1, ma.NotaProva2, ma.NotaProva3,
                        materia.PesoProva1, materia.PesoProva2, materia.PesoProva3);
                    

                    if (mediaPonderada > 4.0M && mediaPonderada < 6.0M)
                    {
                        //simula a prova final
                        ma.NotaProvaFinal = Math.Round(Convert.ToDecimal(random.NextDouble() * 10), 1);
                    }

                    materiaAlunoRep.Insert(ma);
                }
            }
        }

        public bool VerificaSeFazProvaFinal(decimal mediaPonderada)
        {
            if (mediaPonderada > 4.0M && mediaPonderada < 6.0M)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ObterSituacaoMateria(decimal mediaPonderada, decimal mediaAritmetica)
        {
            if (mediaPonderada >= 6.0M)
            {
                return "APROVADO"; 
            }
            else if (mediaPonderada <= 4.0M)
            {
                return "REPROVADO";
            }
            else
            {
                if (mediaAritmetica >= 5.0M)
                {
                    return "APROVADO";
                }
                else
                {
                    return "REPROVADO";
                }
            }
        }
    }
}
