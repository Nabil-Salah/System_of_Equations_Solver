using System;
using System.Collections.Generic;

namespace System_of_Equations_Solver
{
    public abstract class SolveSystem
    {
        protected enum State { ONESOLUTION, INFINTYSOLUTION, NOSOLUTION };
        protected List<List<double>> augmantedMatrix;
        SolveSystem()
        {
            this.augmantedMatrix = new List<List<double>>();
        }
        public SolveSystem(List<List<double>> augmantedMatrix)
        {
            this.augmantedMatrix = augmantedMatrix;
        }
        protected State checkSolve()
        {
            int num_columns = augmantedMatrix[0].Count;
            int num_rows = augmantedMatrix.Count;
            int nonzerocnt = 0;
            for (int i = num_columns - 1; i >= 0; --i)
            {
                if (augmantedMatrix[num_rows - 1][i] != 0)
                {
                    ++nonzerocnt;
                }
            }
            if (nonzerocnt == 0)
            {
                return State.INFINTYSOLUTION;
            }
            else if ((nonzerocnt == 1) && (augmantedMatrix[num_rows - 1][num_columns - 1] != 0))
            {
                return State.NOSOLUTION;
            }
            else if ((nonzerocnt == 1) && (augmantedMatrix[num_rows - 1][num_columns - 1] == 0))
            {
                return State.ONESOLUTION;
            }
            else if ((nonzerocnt == 2) && (augmantedMatrix[num_rows - 1][num_columns - 1] != 0))
            {
                return State.ONESOLUTION;
            }
            else
            {
                return State.NOSOLUTION;
            }
        }
        protected void interChanege(int column, int row)//makeCurrentLead
        {
            int pos = row;
            for (int i = row; i < augmantedMatrix.Count; i++)
            {
                if (augmantedMatrix[i][column] != 0) break;
            }
            if (pos == augmantedMatrix.Count || pos == row) return;
            for(int i = 0; i < augmantedMatrix[pos].Count; i++)
            {
                double temp = augmantedMatrix[pos][i];
                augmantedMatrix[pos][i] = augmantedMatrix[row][i];
                augmantedMatrix[row][i]=temp;
            }
            /*yousef
                
                
                //  R(row) <-> R(pos)  
                //print() array
                
                 
             */
        }
        protected void scalling(int column, int row)//makeLeadOne
        {

        }
        protected void replacement(int column, int row)//make all beneath lead equal 1
        {
            for (int r = row+1; r < row; r++)
            { // for each row ...
                /* calculate divisor and multiplier */
                double d = augmantedMatrix[row][column];
                if (d == 0) continue;
                double m = augmantedMatrix[r][column] / d;
                /*yousef
                
                
                //  R(r) - (augmantedMatrix[r][column] / d)R(row) -> R(r)  
                //print() array
                
                 
                 */
                for (int c = 0; c < column; c++)
                { // for each column ...
                    augmantedMatrix[r][c] -= augmantedMatrix[r][c] * m;  // make other = 0
                }
            }
        }
        public void print()
        {
            for(int i = 0; i < augmantedMatrix.Count; i++)
            {
                for(int j = 0; j < augmantedMatrix[0].Count; j++)
                {
                    Console.Write($"{augmantedMatrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public abstract void echelonForm();
    }
    public class GaussianElimination : SolveSystem
    {
        public GaussianElimination(List<List<double>> augmantedMatrix) : base(augmantedMatrix)
        {

        }
        public override void echelonForm()
        {
            for (int i = 0; i < augmantedMatrix.Count; i++)
            {
                interChanege(i, i);
                scalling(i, i);
                replacement(i, i);
            }
            /*yousef
                
                
                //  final array  
                //print() array
                
                 
            */
            State solvability = checkSolve();
            if (solvability == State.NOSOLUTION)
            {
                /*yousef
                
                //array doesn't have solution
                
                 
            */
            }else if(solvability == State.INFINTYSOLUTION)
            {
                /*yousef
                
                //array have infinite solutions
                
                 
            */
            }
            else
            {
                /*yousef
                
                //array have one solution
                
                 
            */

            }
        }
    }
    public class GaussJordonElimination : SolveSystem
    {
        public GaussJordonElimination(List<List<double>> augmantedMatrix) : base(augmantedMatrix)
        {

        }
        private void gaussJordonExtension(int column, int row)
        {
            for (int r = row - 1; r >= 0; r--)
            { // for each row ...
                /* calculate divisor and multiplier */
                double d = augmantedMatrix[row][column];
                if (d == 0) continue;
                double m = augmantedMatrix[r][column] / d;

                for (int c = 0; c < column; c++)
                { // for each column ...
                    augmantedMatrix[r][c] -= augmantedMatrix[r][c] * m;  // make other = 0
                }
            }
        }
        public override void echelonForm()
        {
            for (int i = 0; i < augmantedMatrix.Count; i++)
            {
                interChanege(i, i);
                scalling(i, i);
                replacement(i, i);
                gaussJordonExtension(i, i);
            }
            /*yousef
                
                
                //  final array  
                //print() array
                
                 
            */
            State solvability = checkSolve();
            if (solvability == State.NOSOLUTION)
            {
                /*yousef
                
                //array doesn't have solution
                
                 
            */
            }
            else if (solvability == State.INFINTYSOLUTION)
            {
                /*yousef
                
                //array have infinite solutions
                
                 
            */
            }
            else
            {
                /*yousef
                
                //array have one solution
                
                 
                
                /*for(int i = 0; i < augmantedMatrix.Count; i++)
                {
                    Console.WriteLine($"X{i + 1} = {augmantedMatrix[i][i]}");
                }*/

            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// checked before of all column zero
            /// checcked for valisdity
            /// </summary>
            List<List<double>> a = new List<List<double>>();
            int sz= int.Parse(Console.ReadLine());
            //take inpput
            for(int i = 0; i < sz; i++)
            {
                a.Add(new List<double>(sz));
                for(int j = 0; j < sz; j++)
                {
                    double tak = double.Parse(Console.ReadLine());
                    a[i].Add(tak);
                }
            }
            int opt = int.Parse(Console.ReadLine());
            
            if (opt == 1)
            {
                GaussianElimination g = new GaussianElimination(a);
                g.echelonForm();
            }
            else
            {
                GaussJordonElimination g = new GaussJordonElimination(a);
                g.echelonForm();
            }
        }
    }
}
//nabil: Put Prototypes - EchelonForm
//Mostafa: CheckSolve - Make Leading Be one
//Gohary:Make Current Lead - Input
//Alaa:Replacement - Gauss Extension