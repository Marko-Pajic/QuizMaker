using System.Collections.Generic;
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
                return UIMethod.GetOptionPreferences();
            }
            else
            {
                return 1;
            }
        }

        public static void XmlSerializer(QuizCategory questionContainer, List<Question> categoryQuestions)
        {
            string directoryPath = Constants.DIRECTORY_FOLDER;
            string fileName = $@"{questionContainer.Name}.xml";
            string filePath = Path.Combine(directoryPath, fileName);

            Directory.CreateDirectory(directoryPath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.Create(fileName))
            {
                serializer.Serialize(file, categoryQuestions);
            }
        }

        public static string GetCategorySelection()
        {
            UIMethod.ShowCategoryInquiry();

            string filePath = Constants.DIRECTORY_FOLDER;
            string[] fileEntries = Directory.GetFiles(filePath);
            string fileEntry;

            for (int i = 0; i < fileEntries.Length; i++)
            {
                fileEntry = fileEntries[i];
                UIMethod.ShowAnswerList(i, fileEntry);
            }

            int numOfChosenCategory = int.Parse(Console.ReadLine());
            string fileToPlay = fileEntries[numOfChosenCategory - 1];
            return fileToPlay;
        }

        public static List<Question> XmlDeserializer(string fileToPlay)
        {
            List<Question> categoryQuestions = new List<Question>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

            using (FileStream file = File.OpenRead(fileToPlay))
            {
                categoryQuestions = serializer.Deserialize(file) as List<Question>;
            }
            return categoryQuestions;
        }
    }
}
