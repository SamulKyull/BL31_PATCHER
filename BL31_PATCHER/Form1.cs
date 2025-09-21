namespace BL31_PATCHER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void UILog(string message)
        {
            int maxLength = 55;
            for (int i = 0; i < message.Length; i += maxLength)
            {
                string line = message.Substring(i, Math.Min(maxLength, message.Length - i));
                LoglistBox1.Items.Add(line);
            }

            LoglistBox1.SelectedIndex = LoglistBox1.Items.Count - 1;
            LoglistBox1.SelectedItem = message;
            LoglistBox1.TopIndex = LoglistBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog instance
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only show .bin files
            openFileDialog.Filter = "BIN Files|*.bin";

            // Show the file open dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path
                string filePath = openFileDialog.FileName;

                // Check if the file name is bl31.bin
                if (System.IO.Path.GetFileName(filePath).ToLower() == "bl31.bin")
                {
                    textBox1.Text = filePath;
                    UILog("Selected file PATH: " + filePath);
                }
                else
                {
                    UILog("Please select a file named 'bl31.bin'.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the file path from the TextBox
            string filePath = textBox1.Text;

            // Check if a file has been selected
            if (string.IsNullOrEmpty(filePath))
            {
                UILog("Please select a file first.");
                return;
            }

            try
            {
                // Read the binary content of the file
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Define the byte sequence to search for (a2788052)
                byte[] targetBytes = new byte[] { 0xa2, 0x78, 0x80, 0x52 };
                // Define the replacement byte sequence (22798052)
                byte[] replacementBytes = new byte[] { 0x22, 0x79, 0x80, 0x52 };

                bool found = false;
                for (int i = 0; i <= fileBytes.Length - targetBytes.Length; i++)
                {
                    // Check if the byte sequence matches starting from the current position
                    if (fileBytes[i] == targetBytes[0] && fileBytes[i + 1] == targetBytes[1] &&
                        fileBytes[i + 2] == targetBytes[2] && fileBytes[i + 3] == targetBytes[3])
                    {
                        // Replace the bytes with the new sequence
                        Array.Copy(replacementBytes, 0, fileBytes, i, replacementBytes.Length);
                        found = true;
                    }
                }

                if (found)
                {
                    // Generate the path for the patched file by adding '_patched' to the original file name
                    string directory = Path.GetDirectoryName(filePath);
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    string patchedFilePath = System.IO.Path.Combine(directory, fileNameWithoutExtension + "_patched.bin");

                    // Save the modified file
                    System.IO.File.WriteAllBytes(patchedFilePath, fileBytes);

                    UILog($"The byte sequence was replaced and saved to: {patchedFilePath}");
                }
                else
                {
                    UILog("The byte sequence 'a2788052' was not found in the file. Skipping patch.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found or invalid format)
                UILog("Error reading the file: " + ex.Message);
            }
        }
    }
}
