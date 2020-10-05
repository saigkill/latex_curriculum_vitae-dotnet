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

using CsvHelper;
using latex_curriculum_vitae.Mappers;
using latex_curriculum_vitae.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace latex_curriculum_vitae.Services
{
    public class CsvParserService : ICsvParserService
    {
        public List<JobApplicationModel> ReadCsvFileToJobApplicationModel(string path)
        {
            try
            {
                using var reader = new StreamReader(path, Encoding.Default);
                using var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<JobApplicationMap>();
                var records = csv.GetRecords<JobApplicationModel>().ToList();
                return records;
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void WriteNewCsvFile(string path, List<JobApplicationModel> jobApplicationModels)
        {
            using StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true));
            using CsvWriter cw = new CsvWriter(sw);
            cw.WriteHeader<JobApplicationModel>();
            cw.NextRecord();
            foreach (JobApplicationModel app in jobApplicationModels)
            {
                cw.WriteRecord<JobApplicationModel>(app);
                cw.NextRecord();
            }
        }
    }
}
