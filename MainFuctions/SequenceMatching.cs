using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Audio;
using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.EMMA;

//using DocumentFormat.OpenXml.EMMA;


//using DocumentFormat.OpenXml.EMMA;

//using DocumentFormat.OpenXml.EMMA;

//using DocumentFormat.OpenXml.EMMA;

//using DocumentFormat.OpenXml.EMMA;

//using DocumentFormat.OpenXml.EMMA;
//using DocumentFormat.OpenXml.Spreadsheet;
using Recorder.MFCC;
using static DataOperations;

namespace Recorder.MainFuctions
{
    internal class SequenceMatching
    {
        private static double infinite = 0x3f3f3f3f;

        static public Dictionary<int, Person_template> sequenceTest = new Dictionary<int, Person_template>();

        private static double EuclideanDistance1(MFCCFrame A, MFCCFrame B)
        {
            double sum = 0;
            for (int i = 0; i < 13; ++i)
            {
                sum += (Math.Pow(A.Features[i] - B.Features[i], 2));
            }
            return Math.Sqrt(sum);
        }
        private static double EuclideanDistance(MFCCFrame f1, MFCCFrame f2)
        {
            double sum = 0.0;
            double diff = 0.0;
            diff = f1.Features[0] - f2.Features[0]; sum += diff * diff;
            diff = f1.Features[1] - f2.Features[1]; sum += diff * diff;
            diff = f1.Features[2] - f2.Features[2]; sum += diff * diff;
            diff = f1.Features[3] - f2.Features[3]; sum += diff * diff;
            diff = f1.Features[4] - f2.Features[4]; sum += diff * diff;
            diff = f1.Features[5] - f2.Features[5]; sum += diff * diff;
            diff = f1.Features[6] - f2.Features[6]; sum += diff * diff;
            diff = f1.Features[7] - f2.Features[7]; sum += diff * diff;
            diff = f1.Features[8] - f2.Features[8]; sum += diff * diff;
            diff = f1.Features[9] - f2.Features[9]; sum += diff * diff;
            diff = f1.Features[10] - f2.Features[10]; sum += diff * diff;
            diff = f1.Features[11] - f2.Features[11]; sum += diff * diff;
            diff = f1.Features[12] - f2.Features[12]; sum += diff * diff;
            return Math.Sqrt(sum);
        }
        public static double DTW(Sequence input, Sequence templete)
        {

            int n = input.Frames.Count();
            int m = templete.Frames.Count();

            double[] last_row = new double[m + 1];
            double[] current_row = new double[m + 1];
            //double[] last_last_row = new double[n + 1];


            for (int i = 0; i <= m; i++)
            {
                last_row[i] = double.PositiveInfinity;
                //last_last_row[i] = double.PositiveInfinity;
                current_row[i] = double.PositiveInfinity;
            }

            last_row[0] = 0;
            double mn;
            for (int i = 1; i <= n; i++)
            {
                current_row[0] = double.PositiveInfinity;
                for (int j = 1; j <= m; j++)
                {

                    //stretching            \\ normal             
                    mn = Math.Min(last_row[j ], last_row[j - 1]);
                    if(j>1)
                    mn = Math.Min(mn, last_row[j - 2]);
                    //mn = Math.Min(mn, last_row[j - 2]);
                    //mn = Math.Min(mn, last_last_row[j - 1]);//shrinking

                    current_row[j] = EuclideanDistance(templete.Frames[j - 1], input.Frames[i - 1]) + mn;
                }
                //Console.WriteLine("min "+current_row[n]);

                //Console.WriteLine("current :" + current_row[0] + " last " + last_row[0] + " last_last " + last_last_row[0]);
                var temp = last_row;
                last_row = current_row;
                current_row = temp;
                //last_last_row = temp;
                //Console.WriteLine("current :" + current_row[0] + " last " + last_row[0] + " last_last " + last_last_row[0]);
            }
            return last_row[m];

        }
        public static double DTWPruning(Sequence input, Sequence templete, int w)
        {
            //int input_len = input.Frames.Count();
            //int temp_len = templete.Frames.Count();

            //w = Math.Max(w, 2 * Math.Abs(temp_len - input_len));
            ////Console.WriteLine("w  " + w);
            //double[] last_last_row = new double[input_len + 1];
            //double[] last_row = new double[input_len + 1];
            //double[] current_row = new double[input_len + 1];

            //for (int i = 0; i <= input_len; i++)
            //{
            //    last_row[i] = double.PositiveInfinity;
            //    last_last_row[i] = double.PositiveInfinity;
            //    current_row[i] = double.PositiveInfinity;
            //}

            //last_row[0] = 0;
            //double mn;
            //int  l, r;
            //double[] temp;
            //for (int i = 1; i <= temp_len; i++)
            //{

            //    l = Math.Max(1, i - (w / 2));
            //    r = Math.Min(input_len, i + (w / 2));
            //    //Console.WriteLine(l + " " + r);

            //    current_row[l - 1] = double.PositiveInfinity;
            //    for (int j = l; j <= r; j++)
            //    {

            //        //Console.WriteLine("cu "+current_row[j - 1]);
            //        //stretching            \\ normal             
            //        mn = Math.Min(current_row[j - 1], last_row[j - 1]);
            //        mn = Math.Min(mn, last_last_row[j - 1]);//shrinking
            //        current_row[j] = EuclideanDistance(templete.Frames[i - 1], input.Frames[j - 1]) + mn;
            //    }
            //    temp = last_row;
            //    last_row = current_row;
            //    current_row = last_last_row;
            //    last_last_row = temp;
            //}

            ////Console.WriteLine("prun" + last_row[n]);
            ////int idx = (int)Math.Min(n, (m * (double)n / m) + w / 2);
            ////Console.WriteLine("idx "+idx);
            ////Console.WriteLine("n "+n);
            //return last_row[input_len];
            int n = input.Frames.Count();
            int m = templete.Frames.Count();
            w = Math.Max(w, 2 * Math.Abs(m - n));


            double[] last_row = new double[m + 1];
            double[] current_row = new double[m + 1];
            //double[] last_last_row = new double[n + 1];


            for (int i = 0; i <= m; i++)
            {
                last_row[i] = double.PositiveInfinity;
                //last_last_row[i] = double.PositiveInfinity;
                current_row[i] = double.PositiveInfinity;
            }

            last_row[0] = 0;
            double mn;
            int  l, r;
            for (int i = 1; i <= n; i++)
            {
                l = Math.Max(1, i - (w / 2));
                r = Math.Min(m, i + (w / 2));
              
                current_row[l - 1] = double.PositiveInfinity;
                for (int j = l; j <= r; j++)
                {

                    //stretching            \\ normal             
                    mn = Math.Min(last_row[j], last_row[j - 1]);
                    if (j > 1)
                        mn = Math.Min(mn, last_row[j - 2]);
                    //mn = Math.Min(mn, last_row[j - 2]);
                    //mn = Math.Min(mn, last_last_row[j - 1]);//shrinking

                    current_row[j] = EuclideanDistance(templete.Frames[j - 1], input.Frames[i - 1]) + mn;
                }
                //Console.WriteLine("min "+current_row[n]);

                //Console.WriteLine("current :" + current_row[0] + " last " + last_row[0] + " last_last " + last_last_row[0]);
                var temp = last_row;
                last_row = current_row;
                current_row = temp;
                //last_last_row = temp;
                //Console.WriteLine("current :" + current_row[0] + " last " + last_row[0] + " last_last " + last_last_row[0]);
            }
            return last_row[m];
        }
        





        static public double CheckTestcaseAccuracy(List<User> testCase, List<string> testcaseResult)
        {
            int misclassifiedSamples = 0;
            int resultIndex = 0;
            for (int i = 0; i < testCase.Count; i++)
            {
                for (int j = 0; j < testCase[i].UserTemplates.Count; j++)
                {
                    if (testCase[i].UserName.Equals(testcaseResult[resultIndex]))
                        misclassifiedSamples++;

                    resultIndex++;
                }
            }

            return (double)misclassifiedSamples / testcaseResult.Count;
        }
    }
}
