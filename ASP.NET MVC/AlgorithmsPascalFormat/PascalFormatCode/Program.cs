using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalFormatCode
{
    class Program
    {
        static int tabsCount = 0;
        const string Tab = "    ";
        public static string[] KeyWords = new string[]
        {
            "interface", 
            "uses", 
            "type", 
            "Type",
            "FUNCTION",	
            "PROCEDURE", 
            "procedure", 
            "private",
            "public", 
            "var", 
            "implementation",
            "begin", 
            "end", 
            "end;",
            "if",
            "else",
            "case",
		    "for",
            "end." 
		};

        static StringBuilder resultCode = new StringBuilder();

        static void Main(string[] args)
        {
            string line = @"unit Unit5; interface uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, Dialogs, ExtCtrls, ComCtrls, StdCtrls,Math; type THSV = class(TForm) GroupBox1: TGroupBox; GroupBox2: TGroupBox; GroupBox3: TGroupBox; GroupBox4: TGroupBox; RangeGroup: TRadioGroup; ImageRGB: TImage; ImageHue: TImage; ImageSaturation: TImage; ImageValue: TImage; ImageRed: TImage; ImageGreen: TImage; ImageBlue: TImage; ImageHS: TImage; TrackBarHue: TTrackBar; TrackBarSaturation: TTrackBar; TrackBarValue: TTrackBar; TrackBarRed: TTrackBar; TrackBarGreen: TTrackBar; TrackBarBlue: TTrackBar; TimerUpdate: TTimer; LabelHue: TLabel; LabelS: TLabel; LabelV: TLabel; LabelR: TLabel; LabelG: TLabel; LabelB: TLabel; LabelHValue: TLabel; LabelSValue: TLabel; LabelVValue: TLabel; LabelRValue: TLabel; LabelGValue: TLabel; LabelBValue: TLabel; //yassen FUNCTION CreateHueSaturationCircle(CONST size: INTEGER; CONST HueLevel: INTEGER; CONST SaturationLevel: INTEGER; CONST ValueLevel: INTEGER; CONST BackgroundColor: TColor; CONST SaturationCircleColor: TColor; CONST HueLineColor: TColor): TBitmap; FUNCTION HSVtoRGBTriple(CONST H,S,V: INTEGER): TRGBTriple; FUNCTION RGBtoRGBTriple(CONST red, green, blue: BYTE): TRGBTriple; PROCEDURE TrackBarOnChangeRGB(r,g,b : Byte); PROCEDURE TrackBarOnChangeHSV(h,s,v : Integer); procedure CircleChange(); procedure UpdateHSfromMouse (CONST X,Y: INTEGER; CONST Sender: TObject); procedure UpdateValue(); procedure UpdateColors(); FUNCTION HLStoRGBTriple (CONST H,L,S: INTEGER): TRGBTriple; FUNCTION ColorToRGBTriple(CONST Color: TColor): TRGBTriple; //yassen krai procedure TrackBarRedChange(Sender: TObject); procedure TrackBarGreenChange(Sender: TObject); procedure TrackBarBlueChange(Sender: TObject); procedure TrackBarHueChange(Sender: TObject); procedure TrackBarSaturationChange(Sender: TObject); procedure TrackBarValueChange(Sender: TObject); procedure TimerUpdateTimer(Sender: TObject); procedure ImageHSMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer); procedure ImageHSMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer); procedure ImageHSMouseUp(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer); private { Private declarations } public { Public declarations } HLS : boolean; end; var HSV: THSV; ChangeRGB, ChangeHSV, CircleFlag, MouseDownFlag : Boolean; Type TRGBTripleArray = ARRAY[0..1300] OF TRGBTriple; pRGBTripleArray = ^TRGBTripleArray; implementation uses color; {$R *.dfm} //yassen FUNCTION THSV.ColorToRGBTriple(CONST Color: TColor): TRGBTriple; BEGIN WITH RESULT DO BEGIN rgbtRed := GetRValue(Color); rgbtGreen := GetGValue(Color); rgbtBlue := GetBValue(Color) END END {ColorToRGBTriple}; FUNCTION THSV.HLStoRGBTriple (CONST H,L,S: INTEGER): TRGBTriple; VAR R,G,B: Real; BEGIN ColorSpace.HLStoRGBReal(H, L/255, S/255, R,G,B); RESULT := ColorToRGBTriple( RGB(ROUND(255*R), ROUND(255*G), ROUND(255*B)) ) END {HLStoRGBTriple}; procedure THSV.UpdateColors(); VAR Bitmap: TBitmap; BEGIN Bitmap := TBitmap.Create; Bitmap.PixelFormat := pf24bit; Bitmap.Width := ImageRGB.Width; Bitmap.Height := ImageRGB.Height; Bitmap.Canvas.Brush.Color := RGB(TrackBarRed.Position, TrackBarGreen.Position, TrackBarBlue.Position); Bitmap.Canvas.FillRect(Bitmap.Canvas.ClipRect); ImageRGB.Picture.Graphic := Bitmap; Bitmap.Free; ImageRGB.Refresh; END {UpdateColors}; procedure THSV.UpdateValue(); begin if RangeGroup.ItemIndex = 1 then begin LabelRValue.Caption := Format('%.3f',[TrackBarRed.Position / 255]); LabelGValue.Caption:=Format('%.3f',[TrackBarGreen.Position / 255]); LabelBValue.Caption:=Format('%.3f',[TrackBarBlue.Position / 255]); LabelHValue.Caption:=Format('%.1f', [TrackBarHue.Position 0.0]); LabelSValue.Caption:=Format('%.3f',[TrackBarSaturation.Position / 255]); LabelVValue.Caption:=Format('%.3f',[TrackBarValue.Position / 255]); end else begin LabelRValue.Caption:=inttostr(TrackBarRed.Position); LabelGValue.Caption:=inttostr(TrackBarGreen.Position); LabelBValue.Caption:=inttostr(TrackBarBlue.Position); LabelHValue.Caption:=inttostr(TrackBarHue.Position); LabelSValue.Caption:=inttostr(TrackBarSaturation.Position); LabelVValue.Caption:=inttostr(TrackBarValue.Position); end; end; PROCEDURE THSV.UpdateHSfromMouse (CONST X,Y: INTEGER; CONST Sender: TObject); VAR Angle : INTEGER; Distance: INTEGER; xDelta : INTEGER; yDelta : INTEGER; Radius : INTEGER; begin Radius := ImageHS.Height DIV 2; xDelta := X - Radius; yDelta := Y - Radius; Angle := ROUND(360 180*ArcTan2(-yDelta,xDelta)/PI); // Make sure range is correct IF Angle < 0 THEN Angle := Angle 360 ELSE IF Angle > 360 THEN Angle := Angle - 360; TrackBarHue.Position := Angle; Distance := ROUND( SQRT( SQR(xDelta) SQR(yDelta)) ); IF Distance >= Radius THEN TrackBarSaturation.Position := 255 ELSE TrackBarSaturation.Position := MulDiv(Distance, 255, Radius); // Simulate change on one of HSV trackbars TrackBarOnChangeHSV(TrackBarHue.Position,TrackBarSaturation.Position, TrackBarValue.Position); END {UpdateHSfromMouse}; procedure THSV.Circlechange(); var BitmapHS : TBitmap; begin BitmapHS := CreateHueSaturationCircle(ImageHS.Height, TrackBarHue.Position, TrackBarSaturation.Position, TrackBarValue.Position, clBtnFace, clSilver, clBlack); ImageHS.Canvas.Draw(0, 0, BitmapHS); BitmapHS.Free; end; PROCEDURE THSV.TrackBarOnChangeRGB(r,g,b : byte); VAR h,s,v : integer; begin if not ChangeRGB then begin ChangeRGB:=true; ColorSpace.RGBtoHSV(h,s,v,TrackBarRed.Position,TrackBarGreen.Position, TrackBarBlue.Position); TrackBarHue.Position:=h; TrackBarSaturation.Position:=s; TrackBarValue.Position:=v; Circlechange(); ChangeRGB:=false; end; end;{TrackBarOnChangeRGB} PROCEDURE THSV.TrackBarOnChangeHSV(h,s,v : Integer); VAR r,g,b : Byte; begin if not ChangeHSV then begin ChangeHSV:=true; if hls then ColorSpace.HLStoRGB(r,g,b,TrackBarHue.Position, TrackBarValue.Position,TrackBarSaturation.Position) else ColorSpace.HSVtoRGB(TrackBarHue.Position,TrackBarSaturation.Position, TrackBarValue.Position,r,g,b); TrackBarRed.Position:=r; TrackBarGreen.Position:=g; TrackBarBlue.Position:=b; Circlechange(); ChangeHSV:=false; end; end;{TrackBarOnChangeHSV} FUNCTION THSV.RGBtoRGBTriple(CONST red, green, blue: BYTE): TRGBTriple; BEGIN WITH RESULT DO BEGIN rgbtRed := red; rgbtGreen := green; rgbtBlue := blue END END {RGBTriple}; FUNCTION THSV.HSVtoRGBTriple (CONST H,S,V: INTEGER): TRGBTriple; CONST divisor: INTEGER = 255*60; VAR f : INTEGER; hTemp: INTEGER; p,q,t: INTEGER; VS : INTEGER; BEGIN IF S = 0 THEN RESULT := RGBtoRGBTriple(V, V, V) // achromatic: shades of gray ELSE BEGIN // chromatic color IF H = 360 THEN hTemp := 0 ELSE hTemp := H; f := hTemp MOD 60; // f is IN [0, 59] hTemp := hTemp DIV 60; // h is now IN [0,6) VS := V*S; p := V - VS DIV 255; // p = v * (1 - s) q := V - (VS*f) DIV divisor; // q = v * (1 - s*f) t := V - (VS*(60 - f)) DIV divisor; // t = v * (1 - s * (1 - f)) CASE hTemp OF 0: RESULT := RGBtoRGBTriple(V, t, p); 1: RESULT := RGBtoRGBTriple(q, V, p); 2: RESULT := RGBtoRGBTriple(p, V, t); 3: RESULT := RGBtoRGBTriple(p, q, V); 4: RESULT := RGBtoRGBTriple(t, p, V); 5: RESULT := RGBtoRGBTriple(V, p, q); ELSE RESULT := RGBtoRGBTriple(0,0,0) // should never happen; // avoid compiler warning END END END {HSVtoRGBTriple}; FUNCTION THSV.CreateHueSaturationCircle(CONST size: INTEGER; CONST HueLevel: INTEGER; CONST SaturationLevel: INTEGER; CONST ValueLevel: INTEGER; CONST BackgroundColor: TColor; CONST SaturationCircleColor: TColor; CONST HueLineColor: TColor): TBitmap; VAR angle : Double; delta : INTEGER; dSquared : INTEGER; H,S,V : INTEGER; i : INTEGER; j : INTEGER; Radius : INTEGER; RadiusSquared: INTEGER; row : pRGBTripleArray; X : INTEGER; Y : INTEGER; BEGIN RESULT := TBitmap.Create; RESULT.PixelFormat := pf24bit; RESULT.Width := size; RESULT.Height := size; // Fill with background color RESULT.Canvas.Brush.Color := BackGroundColor; RESULT.Canvas.FillRect(RESULT.Canvas.ClipRect); Radius := size DIV 2; RadiusSquared := Radius*Radius; V := ValueLevel; FOR j := 0 TO RESULT.Height-1 DO BEGIN Y := Size - 1 - j - Radius; {Center is Radius offset} row := RESULT.Scanline[Size - 1 - j]; FOR i := 0 TO RESULT.Width-1 DO BEGIN X := i - Radius; dSquared := X*X Y*Y; IF dSquared <= RadiusSquared THEN BEGIN S := ROUND( (255 * SQRT(dSquared)) / Radius ); H := ROUND( 180 * (1 ArcTan2(X, Y) / PI)); // 0..360 degrees // Shift 90 degrees so H=0 (red) occurs along ""X"" axis H := H 90; IF H > 360 THEN H := H - 360; if HLS then row[i] := HLStoRGBTriple(H,V,S) else row[i] := HSVtoRGBTriple(H,S,V) END END; END; // Draw Saturation Circle IF SaturationLevel IN [1..254] THEN BEGIN RESULT.Canvas.Pen.Color := SaturationCircleColor; RESULT.Canvas.Brush.Style := bsClear; delta := MulDiv(Radius, SaturationLevel, 255); RESULT.Canvas.Ellipse(Radius - delta, Radius - delta, Radius delta, Radius delta); END; // Draw Hue Line IF (SaturationLevel <> 0) AND ((HueLevel >= 0) AND (HueLevel <= 360)) THEN BEGIN // Use negative value for counterclockwise angles with the ""Y"" // direction going the ""wrong"" (mathematical) way Angle := -HueLevel * PI / 180; RESULT.Canvas.Pen.Color := HueLineColor; RESULT.Canvas.MoveTo(Radius,Radius); RESULT.Canvas.LineTo(Radius Round(Radius*COS(angle)), Radius Round(Radius*SIN(angle))) END; END {CreateHueSaturationCircle}; //yassen krai procedure THSV.TrackBarRedChange(Sender: TObject); begin if not hls then TrackBarOnChangeRGB(TrackBarRed.Position,TrackBarGreen.Position, TrackBarBlue.Position); end; procedure THSV.TrackBarGreenChange(Sender: TObject); begin if not hls then TrackBarOnChangeRGB(TrackBarRed.Position,TrackBarGreen.Position, TrackBarBlue.Position); end; procedure THSV.TrackBarBlueChange(Sender: TObject); begin if not hls then TrackBarOnChangeRGB(TrackBarRed.Position,TrackBarGreen.Position, TrackBarBlue.Position); end; procedure THSV.TrackBarHueChange(Sender: TObject); begin TrackBarOnChangeHSV(TrackBarHue.Position,TrackBarSaturation.Position, TrackBarValue.Position); end; procedure THSV.TrackBarSaturationChange(Sender: TObject); begin TrackBarOnChangeHSV(TrackBarHue.Position,TrackBarSaturation.Position, TrackBarValue.Position); end; procedure THSV.TrackBarValueChange(Sender: TObject); begin TrackBarOnChangeHSV(TrackBarHue.Position,TrackBarSaturation.Position, TrackBarValue.Position); end; procedure THSV.TimerUpdateTimer(Sender: TObject); begin IF CircleFlag THEN BEGIN CircleChange(); CircleFlag := FALSE; END; UpdateValue(); UpdateColors(); end; procedure THSV.ImageHSMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer); begin if MouseDownFlag then UpdateHSfromMouse(X,Y, Sender) end; procedure THSV.ImageHSMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer); begin MouseDownFlag := TRUE; UpdateHSfromMouse(X,Y, Sender) end; procedure THSV.ImageHSMouseUp(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer); begin MouseDownFlag := FALSE end; end.";
            StringBuilder code = new StringBuilder();
            string inputLine = Console.ReadLine();
            while (inputLine.Trim() != "end.")
            {
                code.Append(inputLine + " ");
                inputLine = Console.ReadLine();
            }

            string[] splitedCode = code.ToString().Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedCode.Length; i++)
            {
                for (int j = 0; j < KeyWords.Length; j++)
                {
                    if (splitedCode[i].ToLower().Equals(KeyWords[j]))
                    {
                        ProcessKeyword(KeyWords[j]);
                        break;
                    }
                }

                if (splitedCode[i][splitedCode[i].Length - 1] == ';')
                {
                    resultCode.Append(splitedCode[i] + Environment.NewLine);

                    for (int t = 0; t < tabsCount; t++)
                    {
                        resultCode.Append(Tab);
                    }
                }
                else
                {
                    resultCode.Append(splitedCode[i] + " ");
                }
            }

            tabsCount--;
            Console.WriteLine(resultCode);
        }
  
        private static void ProcessKeyword(string keyword)
        {
            switch (keyword)
            {
                case "type":
                case "var":
                case "begin":
                    tabsCount++;
                    break;
                case "FUNCTION":
                case "case":
                    resultCode.AppendLine();
                    break;
                case "private":
                case "public":
                case "implementation":
                    resultCode.Append("\n" + Tab + keyword + "\n" + Tab);
                    break;
                case "if":
                case "else":
                    resultCode.Append("\n" + Tab + keyword + " "); 
                    break;

                case "for":

                    break;
                case "end":
                case "end;":
                case "end.":
                    resultCode.AppendLine();
                    tabsCount--;
                    break;
                default:
                    break;
            }
        }
    }
}
