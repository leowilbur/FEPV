using System;
using System.Runtime.InteropServices;

namespace FEPV.Views
{
	/// <summary>
	/// VedioCapture 的摘要说明。
	/// </summary>
	public class ClassVedioCapture
	{
		private int hCaptureM;
		private bool isUnLoad = false;
		
		public ClassVedioCapture()
		{        
		}

		~ClassVedioCapture()
		{
			if( !isUnLoad )
			{
				this.UnLoad();
			}
		}

		[DllImport("avicap32.dll")]
		private static extern int capCreateCaptureWindow( string strWindowName, int dwStyle, int x, int y ,int width, int height , int hwdParent, int nID );
		[DllImport("user32.dll")]
		private static extern int SendMessage( int hwnd , int wMsg, int wParam , int lParam );
		[DllImport("user32.dll")]
		private static extern int SendMessage( int hwnd , int wMsg, int wParam , string lParam );
		[DllImport("Kernel32.dll")]
		private static extern bool CloseHandle( int hObject );

		public bool Initialize( System.Windows.Forms.Control aContainer , int intWidth, int intHeight )
		{
			hCaptureM = capCreateCaptureWindow( "", 0x40000000 | 0x10000000, 0,0,intWidth,intHeight,aContainer.Handle.ToInt32() ,1 );
			if( hCaptureM == 0 ) return false;
            
			int ret = SendMessage( hCaptureM , 1034, 0,0 );
			if( ret == 0 )
			{
				CloseHandle(hCaptureM);
				return false;
			}
			//WM_CAP_SET_PREVIEW
			ret = SendMessage( hCaptureM, 1074, 1, 0 );
			if( ret == 0 )
			{
				this.UnLoad();
				return false;
			}
			//WM_CAP_SET_SCALE
			ret = SendMessage( hCaptureM, 1077, 1, 0 );
			if( ret == 0 )
			{
				this.UnLoad();
				return false;
			}
			//WM_CAP_SET_PREVIEWRATE
			ret = SendMessage( hCaptureM, 1076, 66, 0 );
			if( ret == 0 )
			{
				this.UnLoad();
				return false;
			}
			return true;
		}

		public void SingleFrameBegin()
		{
			//
			int ret = SendMessage( hCaptureM, 1094 , 0, 0 );
		}
		public void SingleFrameEnd()
		{
			//
			int ret = SendMessage( hCaptureM, 1095 , 0, 0 );
		}

		public void SingleFrameMode()
		{
			//WM_CAP_GRAB_FRAME
			int ret = SendMessage(  hCaptureM, 1084 , 0, 0 );
			//WM_CAP_SET_PREVIEW 
			//int ret = SendMessage(  hCaptureM, 1074 , 0, 0 );
			//WM_CAP_SINGLE_FRAME
			//ret = SendMessage( hCaptureM, 1096 , 0, 0 );
		}
		public void PreviewMode()
		{
			int ret = SendMessage( hCaptureM, 1074 , 1, 0 );
		}        

		public void UnLoad()
		{
			int ret = SendMessage( hCaptureM, 1035, 0, 0 );
			CloseHandle( this.hCaptureM );
			isUnLoad = true;
		}

		public void CopyToClipBorad()
		{
			int ret = SendMessage(  hCaptureM, 1054, 0, 0 );
		}

		public void ShowFormatDialog()
		{
			int ret = SendMessage(  hCaptureM, 1065, 0, 0 );
		}
		public void SaveToDIB( string fileName )
		{
			int ret = SendMessage(  hCaptureM, 1049, 0, fileName );
		}

		public void ShowDisplayDialog()
		{
			int ret = SendMessage( hCaptureM, 1067, 0, 0 );
		}

		public System.Drawing.Image getCaptureImage()
		{
			System.Windows.Forms.IDataObject iData = System.Windows.Forms.Clipboard.GetDataObject();
			System.Drawing.Image retImage = null;
			if( iData !=  null ) 
			{
				if( iData.GetDataPresent( System.Windows.Forms.DataFormats.Bitmap ) )
				{
					retImage = (System.Drawing.Image)iData.GetData( System.Windows.Forms.DataFormats.Bitmap );
				} 
				else if( iData.GetDataPresent( System.Windows.Forms.DataFormats.Dib  ) )
				{
					retImage = (System.Drawing.Image)iData.GetData( System.Windows.Forms.DataFormats.Dib );
				}
			}
			return retImage;
		}

	}
} 

