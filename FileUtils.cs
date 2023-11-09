using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class FileUtils
    {
        public static int GetExistingFile()
        {
            string directoryPath = @"xml.files";
            bool fileExists = Directory.Exists(directoryPath);
            if (fileExists != false)
            {
                return UIMethod.OptionMenu();
            }
            else 
            {
                return 0; 
            }
        }

        public static void XmlSerializer(QuizCategory questionContainer, List<Question> categoryQuestions)
        {
            string directoryPath = @"xml.files";
            string fileName = $@"{questionContainer.Name}.xml";
            string filePath = Path.Combine(directoryPath, fileName);

            Directory.CreateDirectory(directoryPath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.Create(filePath))
            {
                serializer.Serialize(file, categoryQuestions);
            }
        }
    }
}
