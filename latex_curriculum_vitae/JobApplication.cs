// Copyright (C) 2020 Sascha Manns <Sascha.Manns@outlook.de>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

// Dependencies
using BitlyAPI;
using System.Threading.Tasks;

namespace latex_curriculum_vitae
{
    /// <summary>
    /// This is a class for instancing the JobApplication object
    /// </summary>
    internal class JobApplication
    {
        public string URL { get; set; }
        public string Email { get; set; }
        public string Jobtitle { get; set; }
        public string SubjectPrefix { get; set; }

        /// <summary>
        /// That Constructor creates the JobApplication object by using the arguments.
        /// </summary>
        /// <param name="aurl">comes directly from the gui txtUrl.Text</param>
        /// <param name="aemail">comes directly from the gui txtEmail.Text</param>
        /// <param name="ajobtitle">comes directly from the gui txtJobtitle.Text</param>
        public JobApplication(string aurl, string aemail, string ajobtitle)
        {
            URL = aurl;
            Email = aemail;
            Jobtitle = FixJobApplication(ajobtitle);
            SubjectPrefix = Properties.Resources.Subjectprefix;
        }

        /// <summary>
        /// This method gets the jobtitle and escapes the hash symbol and the ampersand. Otherwise it breaks the LaTEX build.
        /// </summary>
        /// <param name="ajobtitle">comes from the constructor.</param>
        /// <returns></returns>
        public string FixJobApplication(string ajobtitle)
        {
            string _prepare = ajobtitle;
            _prepare = _prepare.Replace(@"#", @"\#");
            _prepare = _prepare.Replace(@"&", @"\&");
            return _prepare;
        }

        public async Task UseBitLy(string apkikey, string url)
        {
            var bitly = new Bitly(apkikey);
            var linkResponse = await bitly.PostShorten(url);
            URL = linkResponse.Link;
        }
    }
}