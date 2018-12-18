// using System;
// using System.Drawing;

// namespace steamStreamSports{
//     public class CreateIcon{ 
//         public void CreateNFLIcon(NFLGame game){
//             Bitmap awayLogo;
//             try
//             {
//                 string awayString = $"{game.Away.Location} {game.Away.Name}";
//                 awayLogo = new Bitmap(Image.FromFile($@"image\logos\nfl\{awayString.Replace(" ","_")}.png"));
//             }
//             catch (Exception ex)
//             {
//                 awayLogo = new Bitmap(0,0);
//             }

//             Bitmap homeLogo;
//             try
//             {
//                 string homeString = $"{game.Home.Location} {game.Home.Name}";
//                 homeLogo = new Bitmap(Image.FromFile($@"image\logos\nfl\{homeString.Replace(" ","_")}.png"));
//             }
//             catch (Exception ex)
//             {
//                 homeLogo = new Bitmap(0,0);
//             }

//             Image frame;
//             try
//             {
//                 frame = Image.FromFile("");
//             }
//             catch (Exception ex)
//             {
//                 return;
//             }

//             using (frame)
//             {
//                 using (var bitmap = new Bitmap(width, height))
//                 {
//                     using (var canvas = Graphics.FromImage(bitmap))
//                     {
//                         canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                         canvas.DrawImage(frame,
//                                         new Rectangle(0,
//                                                     0,
//                                                     width,
//                                                     height),
//                                         new Rectangle(0,
//                                                     0,
//                                                     frame.Width,
//                                                     frame.Height),
//                                         GraphicsUnit.Pixel);
//                         canvas.DrawImage(playbutton,
//                                         (bitmap.Width / 2) - (playbutton.Width / 2),
//                                         (bitmap.Height / 2) - (playbutton.Height / 2));
//                         canvas.Save();
//                     }
//                     try
//                     {
//                         bitmap.Save(/*somekindofpath*/,
//                                     System.Drawing.Imaging.ImageFormat.Jpeg);
//                     }
//                     catch (Exception ex) { }
//                 }
//             }
//         }
//     }
// }