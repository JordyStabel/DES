using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DES_Jordy_Stabel
{
    public partial class Form1 : Form
    {
        string key;
        string message;

        string hexKey;
        string hexMessage;

        int[] binaryKey;
        int[] binaryMessage;

        int[] mainKey = new int[56];

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

        // Convert input to Hexadecimal
        private string ToHex (string input)
        {
            string result = string.Empty;
            char[] array = input.ToCharArray();

            foreach (char letter in array)
            {
                int value = Convert.ToInt32(letter);
                result += string.Format("{0:x}", value).ToUpper();
            }
            return result;
        }

        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
            // Store the orignal inputs
            key = tb_Key.Text;
            message = tb_Message.Text;

            // Convert and store key to hexadecimal
            hexKey = ToHex(key);
            Console.WriteLine("Hex Key: \t\t" + hexKey);

            // Convert and store message to hexadecimal
            hexMessage = ToHex(message);
            Console.WriteLine("Hex Message: \t\t" + hexMessage);

            // Convert and store hex_key to binary
            binaryKey = ToBinary(hexKey);
            Console.Write("\nBinary Key: \t\t");
            foreach (var item in binaryKey)
            {
                Console.Write(item.ToString());
            }

            // Convert and store hex_message to binary
            binaryMessage = ToBinary(hexMessage);
            Console.Write("\nBinary Message: \t");
            foreach (var item in binaryMessage)
            {
                Console.Write(item.ToString());
            }

            // Conevert and store the first key
            mainKey = FirstKeyPermutation(binaryKey);
            Console.Write("\n\nFirst permution: \t");
            foreach (var item in mainKey)
            {
                Console.Write(item.ToString());
            }

            // Creating the first 2 subkeys
            for (int i = 0; i < 28; i++)
            {
                C_keys[i] = mainKey[i];
            }
            Console.Write("\n\nC_Key: \t\t\t");
            foreach (int number in C_keys)
            {
                Console.Write(number);
            }
            for (int i = 0; i < 28; i++)
            {
                D_keys[i] = mainKey[i + 28];
            }
            Console.Write("\nD_Key: \t\t\t");
            foreach (int number in D_keys)
            {
                Console.Write(number);
            }

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

            // Needs to be done with all rightkeys but with the output form the last step
            extededKeys[0] = BitExtender(rightKeys[0]);

            //for (int i = 0; i < extededKeys.Length - 1; i++)
            //{
            //    extededKeys[i] = BitExtender(rightKeys[i]);
            //}


            // Right round one
            int[] RightRound_1_Result = RightRound_1(extededKeys[0], 1);

            // Right round two
            RightRound_2(RightRound_1_Result);


            // ===================================DONE TILL HERE==============================================================================
            // ===================================DONE TILL HERE==============================================================================
            // ===================================DONE TILL HERE==============================================================================
            // ===================================DONE TILL HERE==============================================================================
            // ===================================DONE TILL HERE==============================================================================



            // Make the 32 bit right_0 into a 48 bit key
            //int[] firstExtendedKey = BitExtender(right_0);

            // XOR with right_0
            //int[] RightRound_1_Result = RightRound_1(firstExtendedKey, 1);

            // Second part of XOR
            //int[] RightRound_2_Result = RightRound_2(RightRound_1_Result);
            //Console.WriteLine("Step 2: ");
            //foreach (int number in RightRound_2_Result)
            //{
            //    Console.Write(number + " ");
            //}

            // Third part of XOR
            //int XOR_Part_Three = Third_XOR_Step(XOR_key);
            //Console.WriteLine("Second number: " + XOR_Part_Three);

            // Fourth part of XOR      
            //string XOR_Part_Four = Fourth_XOR_Step(XOR_Part_Two, XOR_Part_Three).ToString();
            //Console.WriteLine("Third number: " + XOR_Part_Four);

            // Fifth part of XOR
            //string result = ToBinary(XOR_Part_Four);
            //Console.WriteLine(result);
        }

        // Converts input to binary
        private int[] ToBinary (string input)
        {
            int[] result = new int[64];

            string temp = string.Join(string.Empty, input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            for (int i = 0; i < temp.Length - 1; i++)
            {
                result[i] = Int32.Parse(temp.Substring(i, 1));
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

        private int[] BitExtender(int[] input)
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

            for (int i = 0; i < (input.Length - 1) / 6; i++)
            {
                result[i] = ((input[i] * 2) + input[i + 5]);
            }

            Console.Write("\nStep 2: \t\t");

            foreach (int x in result)
            {
                Console.Write(x + "  ");
            }

            return result;
        }
        
        private int RightRound_3 (string input)
        {
            int index = 1;
            int multiplier = 8;

            int a = Int32.Parse(input.Substring(index, 1));
            index++;
            int b = Int32.Parse(input.Substring(index, 1));
            index++;
            int c = Int32.Parse(input.Substring(index, 1));
            index++;
            int d = Int32.Parse(input.Substring(index, 1));

            int result = ((a * multiplier) + (b * (multiplier / 2)) + (c * (multiplier / 4)) + d);

            return result;
        }

        private int Fourth_XOR_Step(string input, int indexer)
        {
            int rowIdex = Int32.Parse(input);

            int result = blocks[0][rowIdex][indexer];
            return result;
        }

        private void RightRound(string input)
        {


        }

        private int[] ToIntArray (string[] input)
        {
            int[] result = new int[input.Length];

            for (int i = 0; i < input.Length - 1; i++)
            {
                result[i] = Int32.Parse(input[i]);
            }
            return result;
        }

        private string[] ToStringArray (int[] input)
        {
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length - 1; i++)
            {
                result[i] = input[i].ToString();
            }
            return result;
        }
    }
}

// Step one --> works
// 110100001001000100001010010001110010001101011110
// 110100001001000100001010010001110010001101011110

// First permutation --> works
// 00000000000011111111000011110110010010001011000000001101
// 00000000000011111111000011110110010010001011000000001101

// First temp key --> works
// 00000000000111111110000111101100100100010110000000011010
// 00000000000111111110000111101100100100010110000000011010

// Actual keys --> works
// 100011101100000101110011101010000000100001111011
// 100011101100000101110011101010000000100001111011

// Extended key --> works
// 000000000001011110100000000000000000001100001000
// 000000000001011110100000000000000000001100001000

// Step one --> works
// 110100001001000100001010010001110010001101011110
// 110100001001000100001010010001110010001101011110