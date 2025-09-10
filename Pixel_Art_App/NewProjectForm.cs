namespace ITnetwork_Pixel_Art_Improved
{
    public partial class NewProjectForm : Form
    {
        public MyCanvas _canvas;
        public Size _maxSize;
        public bool _isMatrixVisible;
        public NewProjectForm(MyCanvas canvas, bool isMatrixVisible)
        {
            InitializeComponent();
            _canvas = canvas;
            _maxSize = canvas.MAX_SIZE;
            _isMatrixVisible = isMatrixVisible;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            _canvas = new MyCanvas((int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value, _canvas.CurrentSize, _maxSize, 1, _isMatrixVisible);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
