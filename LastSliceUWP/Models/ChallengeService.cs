using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LastSliceUWP.Models
{
    public class ChallengeService
    {
        private const string CHALLENGE_ROOT_URL = "https://kneadmoredough.azurewebsites.net/";

        private const string CHALLENGE_TWO_URL = CHALLENGE_ROOT_URL + "api/ChallengeTwo";

        private HttpClient client;

        public ChallengeService()
        {
            string tenant = "thelastslice.onmicrosoft.com";
            string clientId = "17315b0a-1d61-41c1-a614-aaa908fc6c3c";
            string webApiId = "webapi";
            string webApiResourceId = string.Format("https://{0}/{1}", tenant, webApiId);
            string signUpSignInPolicy = "B2C_1_SignUp_SignIn";
            string webApiScope = "default_scope";
            string[] scopes = new string[] { string.Format("https://{0}/{1}/{2}", tenant, webApiId, webApiScope) };
            client = new HttpClient(tenant, clientId, webApiResourceId, scopes, signUpSignInPolicy);
        }

        #region Login Methods

        public void ClearUserCache()
        {
            client.ClearCache();
        }

        public bool HasUserLoggedIn()
        {
            bool cachedUserExists = client.CachedUserExists();
            return cachedUserExists;
        }

        public async Task<string> Login()
        {
            string token = await client.GetAccessTokenAsync();
            return token;
        }

        #endregion

        #region Puzzle Methods

        public async Task<string> GetPuzzle()
        {
            var result = await client.GetUrlAsync(CHALLENGE_TWO_URL);
            string puzzleContent = await result.Content.ReadAsStringAsync();
            Print("Challenge Two puzzle", puzzleContent);
            return puzzleContent;
        }

        public async Task<string> PostSolutionToPuzzle(string solution)
        {
            var result = await client.PostUrlAsync(CHALLENGE_TWO_URL, solution);
            string solutionContent = await result.Content.ReadAsStringAsync();
            Print("Challenge Two solution response", solutionContent);
            return solutionContent;
        }

        #endregion

        #region Utility Methods

        private void Print(string message, string s)
        {
            Print(string.Format("{0}:\n {1}", message, s));
        }

        private void Print(string message)
        {
            Debug.WriteLine(message);
        }

        #endregion

        #region Solution Methods

        private string GetId(string message) {
            string b = message.Substring(223, 36);
            return b;
        }

        private string[] GetPayload(string message) {
            string a = message.Substring(20, 194);
            a = a.Replace("\"", "");
            char[] splitchar = { ',' };
            string[] c = a.Split(splitchar);
            return c;
        }

        private string[] GetLines15(string[] c) {
            int[,] stringer = Worder.Stringer15();
            int[,] positioner = Worder.Positioner15();
            int size = stringer.GetLength(0);
            int innerSize = stringer.Length / size;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = "";
                for (int j = 0; j < innerSize; j++)
                {
                    result[i] = result[i] + c[stringer[i, j]].Substring(positioner[i, j], 1);
                }
                result[i] = result[i] + result[i];
            }

            return result;
        }

        private string[] GetLines20(string[] c)
        {
            int[,] stringer = Worder.Stringer20();
            int[,] positioner = Worder.Positioner20();
            int size = stringer.GetLength(0);
            int innerSize = stringer.Length / size;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = "";
                for (int j = 0; j < innerSize; j++)
                {
                    result[i] = result[i] + c[stringer[i, j]].Substring(positioner[i, j], 1);
                }
                result[i] = result[i] + result[i];
            }

            return result;
        }

        private string[] GetLines5(string[] c)
        {
            int[,] stringer = Worder.Stringer5();
            int[,] positioner = Worder.Positioner5();
            int size = stringer.GetLength(0);
            int innerSize = stringer.Length / size;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = "";
                for (int j = 0; j < innerSize; j++)
                {
                    result[i] = result[i] + c[stringer[i, j]].Substring(positioner[i, j], 1);
                }
            }

            return result;
        }

        private List<Worder> StringFinder(string[] c, int pk) {
            int[,] stringer;
            int[,] positioner;
            string[,] directioner;
            if(pk==15)
            {
                stringer = Worder.Stringer15();
                positioner = Worder.Positioner15();
                directioner = Worder.Directioner15();
            }
            else if(pk==5)
            {
                stringer = Worder.Stringer5();
                positioner = Worder.Positioner5();
                directioner = Worder.Directioner5();
            }
            else
            {
                stringer = Worder.Stringer20();
                positioner = Worder.Positioner20();
                directioner = Worder.Directioner20();
            }
            string[] internalWords = { "ANCHOVY", "BACON", "CHEESE", "GARLIC", "GREENPEPPER", "HABANERO", "JALAPENO", "MUSHROOMS", "OLIVE", "ONION", "PINEAPPLE",
                "PEPPERONI", "SAUSAGE" };
            string[] externalWords = { "SALAMI", "AVOCADO", "PEANUTBUTTER" };

            string[] externalWordsC = { "TUNA" };

            string[] externalWordsB = { "SALAMI", "AVOCADO", "SODA", "SEGMINA", "PEANUTBUTTER", "TUNA", "BONE", "CHOKE", "BHEL", "SEAL", "TUBE" };

            bool[] internalFlag = new bool[internalWords.Length];
            bool[] externalFlag = new bool[externalWords.Length];

            List<Worder> internalList = new List<Worder>();
            List<Worder> externalList = new List<Worder>();

            for (int i = 0; i < c.Length; i++) {
                string currComparator = c[i];
                string result = new string(currComparator.ToCharArray());
                for (int j = 0; j < internalWords.Length; j++) {
                    string currWord = internalWords[j];
                    int match = currComparator.IndexOf(currWord);
                    if (match != -1)
                    {
                        while (result.IndexOf(currWord) != -1)
                            result = result.Replace(currWord, "");
                        internalList.Add(new Worder(currWord, positioner[i, match], stringer[i, match], directioner[i, match]));
                    }
                }
                for (int j = 0; j < externalWords.Length; j++) {
                    string currWord = externalWords[j];
                    int match = currComparator.IndexOf(currWord);
                    if (match != -1)
                    {
                        while (result.IndexOf(currWord) != -1)
                            result = result.Replace(currWord, "");
                        externalList.Add(new Worder(currWord, positioner[i, match], stringer[i, match], directioner[i, match]));
                    }
                }
                Print(result);
            }

            internalList.AddRange(externalList);

            return internalList;
        }

        private string Joiner(List<Worder> input) {
            string result = input[0].toString();
            for (int i = 1; i < input.Count; i++)
                result = result + "," + input[i].toString();
            return result;
        }

        public string Solver(string message) {
            string Id = GetId(message);
            string[] payload = GetPayload(message);

            Print(" ");
            Print("Printing Payload:");
            foreach (string load in payload) {
                Print(load);
            }

            string[] lines15 = GetLines15(payload);
            string[] lines20 = GetLines20(payload);
            string[] lines5 = GetLines5(payload);

            Print(" ");
            Print("Printing Lines:");
            foreach (string load in lines15) {
                Print(load);
            }
            foreach (string load in lines20)
            {
                Print(load);
            }
            foreach (string load in lines5)
            {
                Print(load);
            }

            Print(" ");
            Print("Printing Words Removed:");
            List<Worder> solution = StringFinder(lines15, 15);
            solution.AddRange(StringFinder(lines20, 20));
            solution.AddRange(StringFinder(lines5, 5));

            Print(" ");
            Print("Printing solution:");
            foreach (Worder load in solution)
                Print(load.toString());

            string result = Joiner(solution);
            result = "{\"PuzzleId\": \"" + Id + "\",\"Words\": [" + result + "],\"Initials\":\"PRA\"}";

            Print(" ");
            Print("Printing resultLoad:");
            Print(result);

            return result;
        }

        #endregion
    }
}
