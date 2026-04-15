namespace Mediaplayer
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";
            Panel[] panels = { panel6, panel2, panel3, panel4, panel5, panel7 };

            foreach (Panel pnl in panels)
            {
                pnl.MouseMove += Panel_MouseMove;
                pnl.MouseLeave += Panel_MouseLeave;
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.BackColor = ColorTranslator.FromHtml("#993399");
        }
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.BackColor = Color.Purple;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Playlist.Items.AddRange(openFileDialog1.FileNames);
        }
        private void Playlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Playlist.SelectedItem != null)
            {
                axWindowsMediaPlayer1.URL = Playlist.SelectedItem.ToString();
            }
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Playlist.SelectedIndex = Playlist.SelectedIndex + 1;
                axWindowsMediaPlayer1.URL = Playlist.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not More");
            }
        }

        private void perbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Playlist.SelectedIndex = Playlist.SelectedIndex - 1;
                axWindowsMediaPlayer1.URL = Playlist.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Pervious");
            }
        }

        private void volume_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = volume.Value;

            if (axWindowsMediaPlayer1.settings.mute && volume.Value > 0)
                axWindowsMediaPlayer1.settings.mute = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            volume.Minimum = 0;
            volume.Maximum = 100;
            volume.Value = 50;
            axWindowsMediaPlayer1.settings.volume = 50;
        }
        private bool isFullscreen = false;
        private void fullscreen_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }
        bool isPlaying = false;
        private void playbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Playlist.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Item");
                    return;
                }

                if (axWindowsMediaPlayer1.URL != Playlist.SelectedItem.ToString())
                {
                    axWindowsMediaPlayer1.URL = Playlist.SelectedItem.ToString();
                }

                axWindowsMediaPlayer1.Ctlcontrols.play();

                isPlaying = true;
                playbtn.Visible = false;
                pause.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pause_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();

            isPlaying = false;
            pause.Visible = false;
            playbtn.Visible = true;

        }

        private void volbox_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            volbox.Visible = false;
            volback.Visible = true;
        }

        private void Mute_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.mute = !axWindowsMediaPlayer1.settings.mute;

            if (axWindowsMediaPlayer1.settings.mute)
            {
                Mute.Image = Unmute.Image ;
            }
            else
            {
                Mute.Image = Muteagain.Image;    
            }
        }
        private void volback_Click(object sender, EventArgs e)
        {
            panel11.Visible = false;
            volbox.Visible =true;
            volback.Visible = false;
        }
    }
}
