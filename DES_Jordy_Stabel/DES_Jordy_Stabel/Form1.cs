using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DES_Jordy_Stabel
{
    public partial class Form1 : Form
    {
        string hexKey;
        string hexMessage;

        int[] binaryKey;
        int[] binaryMessage;

        int[] mainKey = new int[56];

        bool isC_keys = true;
        int[] C_keys = new int[28];
        int[] D_keys = new int[28];

        int[][] subKeys = new int[16][];
        int[][] Keys = new int[16][];

        int[][] extededKeys = new int[16][];

        int[] left_0 = new int[32];
        int[] right_0 = new int[32];

        int[][] rightKeys = new int[17][];

        int[] IP;

        int[][] C_leftShiftedKeys = new int[17][];
        int[][] D_leftShiftedKeys = new int[17][];

        #region Crap load of hard coded arrays

        int[] firstKeyOrder = new int[] 
        {
            57, 49, 41, 33, 25, 17, 9,
            1,  58, 50, 42, 34, 26, 18,
            10, 2,  59, 51, 43, 35, 27,
            19, 11, 3,  60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7,  62, 54, 46, 38, 30, 22,
            14, 6,  61, 53, 45, 37, 29,
            21, 13, 5,  28, 20, 12, 4
        };

        int[] leftShifts = new int[]
        {
            1, 1, 2, 2, 2, 2, 2, 2,
            1, 2, 2, 2, 2, 2, 2, 1
        };

        int[] secondKeyOrder = new int[]
        {
            14, 17, 11, 24, 1,  5,
            3,  28, 15, 6,  21, 10,
            23, 19, 12, 4,  26, 8,
            16, 7,  27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        int[] IP_Order = new int[]
        {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9 , 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        int[] bitExtenderOrder = new int[]
        {
            32, 1,  2,  3,  4,  5,
            4,  5,  6,  7,  8,  9,
            8,  9,  10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        };

        int[] S_Permutation = new int[]
        {
            16, 7,  20, 21, 29, 12, 28, 17,
            1,  15, 23, 26, 5,  18, 31, 10,
            2,  8,  24, 14, 32, 27, 3,  9,
            19, 13, 30, 6,  22, 11, 4,  25
        };

        int[] FinalPermutation = new int[]
        {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9 , 49, 17, 57, 25
        };

        #endregion

        int[][] S1 = new int[4][];
        int[][] S2 = new int[4][];
        int[][] S3 = new int[4][];
        int[][] S4 = new int[4][];
        int[][] S5 = new int[4][];
        int[][] S6 = new int[4][];
        int[][] S7 = new int[4][];
        int[][] S8 = new int[4][];

        int[][][] blocks = new int[8][][];


        public Form1()
        {
            InitializeComponent();

            #region All S blocks

            S1[0] = new int[] { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 };
            S1[1] = new int[] { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 };
            S1[2] = new int[] { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 };
            S1[3] = new int[] { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 };

            S2[0] = new int[] { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 };
            S2[1] = new int[] { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 };
            S2[2] = new int[] { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 };
            S2[3] = new int[] { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 };

            S3[0] = new int[] { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 };
            S3[1] = new int[] { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 };
            S3[2] = new int[] { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 };
            S3[3] = new int[] { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 };

            S4[0] = new int[] { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 };
            S4[1] = new int[] { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 };
            S4[2] = new int[] { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 };
            S4[3] = new int[] { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 };

            S5[0] = new int[] { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 };
            S5[1] = new int[] { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 };
            S5[2] = new int[] { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 };
            S5[3] = new int[] { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 };

            S6[0] = new int[] { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 };
            S6[1] = new int[] { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 };
            S6[2] = new int[] { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 };
            S6[3] = new int[] { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 };

            S7[0] = new int[] { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 };
            S7[1] = new int[] { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 };
            S7[2] = new int[] { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 };
            S7[3] = new int[] { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 };

            S8[0] = new int[] { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 };
            S8[1] = new int[] { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 };
            S8[2] = new int[] { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 };
            S8[3] = new int[] { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 };

            #endregion

            blocks[0] = S1;
            blocks[1] = S2;
            blocks[2] = S3;
            blocks[3] = S4;
            blocks[4] = S5;
            blocks[5] = S6;
            blocks[6] = S7;
            blocks[7] = S8;
        }

        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
            // Convert and store key to hexadecimal
            hexKey = ToHex(tb_Key.Text);

            // Convert and store message to hexadecimal
            hexMessage = ToHex(tb_Message.Text);

            // Convert and store hex_key to binary
            binaryKey = ToBinary(hexKey);

            // Convert and store hex_message to binary
            binaryMessage = ToBinary(hexMessage);

            // Conevert and store the first key
            mainKey = FirstKeyPermutation(binaryKey);

            // Creating the first 2 subkeys
            C_keys = SplitFirstKey(mainKey);
            D_keys = SplitFirstKey(mainKey);

            Console.Write("\n\nC left shift keys:");
            C_leftShiftedKeys[0] = C_keys;

            for (int i = 1; i <= leftShifts.Length; i++)
            {
                C_leftShiftedKeys[i] = LeftShift(C_leftShiftedKeys[i - 1], (i - 1));
                Console.Write("\nRound " + i + ": \t\t");
                foreach (int number in C_leftShiftedKeys[i])
                {
                    Console.Write(number);
                }
            }

            Console.Write("\n\nD left shift keys:");
            D_leftShiftedKeys[0] = D_keys;

            for (int i = 1; i <= leftShifts.Length; i++)
            {
                D_leftShiftedKeys[i] = LeftShift(D_leftShiftedKeys[i - 1], (i - 1));
                Console.Write("\nRound " + i + ": \t\t");
                foreach (int number in D_leftShiftedKeys[i])
                {
                    Console.Write(number);
                }
            }

            Console.Write("\n\nSubkeys:");
            // Creating the full temp-subkeys, from the C & D subkey parts
            for (int i = 1; i <= 16; i++)
            {
                CreatingSubKeys(i);
                Console.Write("\nKey" + i + ":\t\t\t");
                CreatingKeys(i);
            }

            // Creating a permutation from the message
            IP = Create_IP(binaryMessage);
            Console.Write("\nInitial permutation: \t");
            foreach (int number in IP)
            {
                Console.Write(number);
            }

            // Splitting the IP in two parts 
            for (int i = 0; i < IP.Length - 1; i++)
            {
                if (i < 32)
                {
                    left_0[i] = IP[i];
                }
                else
                {
                    right_0[i - 32] = IP[i];
                }
            }

            rightKeys[0] = right_0;

            Console.Write("\nLeft: \t\t\t");
            foreach (int number in left_0)
            {
                Console.Write(number);
            }

            Console.Write("\nRight: \t\t\t");
            foreach (int number in rightKeys[0])
            {
                Console.Write(number);
            }

            for (int i = 0; i < 16; i++)
            {
                extededKeys[i] = BitExtender(rightKeys[i]);

                int[] RightRound_1_Result = RightRound_1(extededKeys[i], i + 1);

                int[] RightRound_2_Result = RightRound_2(RightRound_1_Result);

                int[] RightRound_3_Result = RightRound_3(RightRound_1_Result);

                int[] RightRound_4_Result = RightRound_4(RightRound_2_Result, RightRound_3_Result);

                string temp = string.Empty;
                for (int j = 0; j < RightRound_4_Result.Length; j++)
                {
                    temp += Convert.ToString(RightRound_4_Result[j], 2).PadLeft(4, '0');
                }
                Console.Write("\nBack to binary: \t" + temp);

                int[] Round4_Binary = new int[temp.Length];

                for (int k = 0; k < Round4_Binary.Length; k++)
                {
                    Round4_Binary[k] = Convert.ToInt32(temp.Substring(k, 1));
                }

                int[] RightRound_5_Result = S_Block_Permutation(Round4_Binary);
                Console.Write("\nS block permutation: \t");
                foreach (int number in RightRound_5_Result)
                {
                    Console.Write(number);
                }

                int[] EndRoundResult = new int[32];

                for (int x = 0; x < EndRoundResult.Length - 1; x++)
                {
                    if (i == 0)
                    {
                        EndRoundResult[x] = ((left_0[x] + RightRound_5_Result[x]) % 2);
                    }
                    else
                    {
                        EndRoundResult[x] = ((rightKeys[i - 1][x] + RightRound_5_Result[x]) % 2);
                    }
                }
                Console.Write("\n\nRight " + (i + 1) + ": \t\t");
                foreach (int number in EndRoundResult)
                {
                    Console.Write(number);
                }
                rightKeys[i + 1] = EndRoundResult;
            }

            //// Needs to be done with all rightkeys but with the output form the last step
            //extededKeys[0] = BitExtender(rightKeys[0]);

            //// Right round one
            //int[] RightRound_1_Result = RightRound_1(extededKeys[0], 1);

            //// Right round two
            //int[] RightRound_2_Result = RightRound_2(RightRound_1_Result);

            //// Right round three, also need result from round 1
            //int[] RightRound_3_Result = RightRound_3(RightRound_1_Result);

            //// Right roud four
            //int[] RightRound_4_Result = RightRound_4(RightRound_2_Result, RightRound_3_Result);

            //int[] RightRound_4_Binary_Result = ToBinary(input);
            //string test = string.Empty;

            //// Right round 4.1 (back to binary)
            //for (int i = 0; i < RightRound_4_Result.Length; i++)
            //{
            //    test += Convert.ToString(RightRound_4_Result[i], 2).PadLeft(4, '0');
            //}

            //Console.Write("\nBack to binary: \t" + test);

            //int[] Round4_Binary = new int[test.Length];

            //for (int i = 0; i < Round4_Binary.Length; i++)
            //{
            //    Round4_Binary[i] = Convert.ToInt32(test.Substring(i, 1));
            //}

            //int[] RightRound_5_Result = S_Block_Permutation(Round4_Binary);
            //Console.Write("\nS block permutation: \t");
            //foreach (int number in RightRound_5_Result)
            //{
            //    Console.Write(number);
            //}

            //int[] EndRoundResult = new int[32];
            //// Need to store damn and increase the index
            //// rightKeys[1] = EndRoundResult;

            //for (int i = 0; i < EndRoundResult.Length - 1; i++)
            //{
            //    EndRoundResult[i] = ((left_0[i] + RightRound_5_Result[i]) % 2);
            //}
            //Console.Write("\n\nRight 1: \t\t");
            //foreach (int number in EndRoundResult)
            //{
            //    Console.Write(number);
            //}

            // TODO: Repeat this 15 times, each time with the 'right key' as input for the next round
        }

        // Convert input to Hexadecimal
        private string ToHex(string input)
        {
            string result = string.Empty;
            char[] array = input.ToCharArray();

            foreach (char letter in array)
            {
                int value = Convert.ToInt32(letter);
                result += string.Format("{0:x}", value).ToUpper();
            }
            Console.WriteLine("Hex: \t\t\t" + result);
            return result;
        }

        // Converts input to binary
        private int[] ToBinary (string input)
        {
            int[] result = new int[input.Length * 4];

            string temp = string.Join(string.Empty, input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            for (int i = 0; i < temp.Length - 1; i++)
            {
                result[i] = Int32.Parse(temp.Substring(i, 1));
            }
            Console.Write("\nBinary: \t\t");
            foreach (var number in result)
            {
                Console.Write(number.ToString());
            }
            return result;
        }

        private int[] FirstKeyPermutation (int[] input)
        {
            int[] result = new int[56];

            for (int i = 0; i < firstKeyOrder.Length; i++)
            {
                result[i] = input[firstKeyOrder[i] - 1];
            }

            Console.Write("\n\nFirst permution: \t");
            foreach (var number in result)
            {
                Console.Write(number.ToString());
            }

            return result;
        }

        private int[] SplitFirstKey (int[] input)
        {
            int[] result = new int[input.Length / 2];
            int delta = 0;

            if (!isC_keys)
            {
                delta = 28;
            }

            for (int i = 0; i < 28; i++)
            {
                result[i] = mainKey[i + delta];
            }
            isC_keys = false;
            Console.Write("\n\nKey: \t\t\t");
            foreach (int number in result)
            {
                Console.Write(number);
            }

            return result;
        }

        private int[] LeftShift (int[] keyArray, int round)
        {
            int[] key = new int[28];

            for (int i = 0; i <= keyArray.Length - 1; i++)
            {
                // If the index is less than 0 and the amount of numbers that have been moved from the back to front (32 becomes 1) is less than the number of leftshifts
                if (i + leftShifts[round] >= 28)
                {
                    key[i] = keyArray[i + leftShifts[round] - 28];
                }
                else
                {
                    key[i] = keyArray[i + leftShifts[round]];
                }
            }

            return key;
        }

        private void CreatingSubKeys (int round)
        {
            int[] temp = new int[56];

            for (int i = 0; i < 56; i++)
            {
                if (i <= 27)
                {
                    temp[i] = C_leftShiftedKeys[round][i];
                }
                else
                {
                    temp[i] = D_leftShiftedKeys[round][i - 28];
                }
            }

            subKeys[round - 1] = temp;

            Console.Write("\nC" + round + "D" + round + "\t\t\t");
            foreach (int number in temp)
            {
                Console.Write(number);
            }
        }

        private void CreatingKeys (int round)
        {
            int[] key = new int[48];
            int i = 0;

            foreach (int index in secondKeyOrder)
            {
                key[i] = subKeys[round - 1][index - 1];
                i++;
            }

            Keys[round - 1] = key;

            foreach (int number in key)
            {
                Console.Write(number);
            }
            Console.Write("\n");
        }

        private int[] Create_IP (int[] input)
        {
            int[] result = new int[64];
            int i = 0;

            foreach (int index in IP_Order)
            {
                result[i] = input[index - 1];
                i++;
            }

            return result;
        }

        private int[] BitExtender (int[] input)
        {
            int[] extendedKey = new int[48];
            int j = 0;
            
            foreach (int index in bitExtenderOrder)
            {
                extendedKey[j] = input[index - 1];
                j++;
            }
            Console.Write("\n\nExtended key: \t\t");
            foreach (int number in extendedKey)
            {
                Console.Write(number);
            }

            return extendedKey;
        }

        private int[] RightRound_1(int[] input, int round)
        {
            int[] result = new int[48];

            for (int i = 0; i < input.Length; i++)
            {
                //string key = subKeys[round - 1].ToString();
                result[i] = ((input[i] + Keys[round - 1][i]) % 2);
            }
            Console.Write("\nStep 1: \t\t");

            foreach (int x in result)
            {
                Console.Write(x);
            }
            return result;
        }

        // Input --> result form RightRound_1
        private int[] RightRound_2 (int[] input)
        {
            int[] result = new int[8];
            int index = 0;

            for (int i = 0; i < input.Length - 1; i += 6)
            {
                result[index] = ((input[i] * 2) + input[i + 5]);
                index++;
            }

            Console.Write("\nStep 2: \t\t");

            foreach (int x in result)
            {
                Console.Write(x + "  ");
            }

            return result;
        }

        private int[] RightRound_3 (int[] input)
        {
            int[] result = new int[8];
            int index = 0;

            for (int i = 0; i < input.Length - 1; i += 6)
            {
                // 8 --> 4 --> 2 --> 1
                result[index] = ((input[i + 1] * 8) + (input[i + 2] * 4) + (input[i + 3] * 2) + input[i + 4]);
                index++;
            }

            Console.Write("\nStep 3: \t\t");

            foreach (int x in result)
            {
                Console.Write(x + "  ");
            }

            return result;
        }

        private int[] RightRound_4(int[] round_2, int[] round_3)
        {
            int[] result = new int[8];

            for (int i = 0; i < round_2.Length; i++)
            {
                result[i] = blocks[i][round_2[i]][round_3[i]];
            }

            Console.Write("\nStep 4: \t\t");

            foreach (int x in result)
            {
                Console.Write(x + "  ");
            }

            return result;
        }

        private int[] S_Block_Permutation(int[] input)
        {
            int[] result = new int[input.Length];

            for (int i = 0; i < S_Permutation.Length; i++)
            {
                result[i] = input[S_Permutation[i] - 1];
            }

            return result;
        }
    }
}