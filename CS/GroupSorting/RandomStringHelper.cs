// Developer Express Code Central Example:
// How to apply sorting by Summary along with sorting by the Column.
// 
// This example shows how to sort group summary items along with the column that
// the summary is aligned with.
// To add this functionality, you can use the
// proposed helper class (GroupSummaryOptions) in your solution. Just set the
// attached property of the Grid to "True".
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4611

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXSample {
    public class RandomStringHelper {
        static Random rnd = new Random();
        static string letters = "abcdefghijklmnopqrstuvwxyz";

        public static string GetRandomString(){
            int length = rnd.Next(6, 20);
            string retVal = ("" + letters[rnd.Next(25)]).ToUpper();

            for (int i = 0; i < length - 1; i++)
                retVal += letters[rnd.Next(25)];

            return retVal;
        }
    }
}
