using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PCPRO_실기
{
    public partial class IOForm : Form
    {
        Thread thd_IOUpdate;
        bool bIOUpdate;
        PLC _plc1, _plc2;
        public IOForm(PLC plc1, PLC plc2)
        {
            InitializeComponent();
            _plc1 = plc1;
            _plc2 = plc2;
            thd_IOUpdate = new Thread(new ThreadStart(IOUpdata));
        }

        private void IOForm_Load(object sender, EventArgs e)
        {
            bIOUpdate = true;
            thd_IOUpdate.Start();
        }

        private void IOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bIOUpdate = false;
        }

        private void IOForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            thd_IOUpdate.Join();
        }

        private void IOUpdata()
        {
            while (bIOUpdate)
            {
                // Module1 입력
                if (!_plc1._plc1DeviceX[(int)Module1X.md1_SupplyCylinderFWD]) btn_X02.BackColor = Color.Gray;
                else btn_X02.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD]) btn_X03.BackColor = Color.Gray;
                else btn_X03.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeZAxisUpLimit]) btn_X0A.BackColor = Color.Gray;
                else btn_X0A.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeZAxisDownLimit]) btn_X0B.BackColor = Color.Gray;
                else btn_X0B.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeZAxisHome]) btn_X0C.BackColor = Color.Gray;
                else btn_X0C.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeXAxisRightLimit]) btn_X0D.BackColor = Color.Gray;
                else btn_X0D.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeXAxisLeftLimit]) btn_X0E.BackColor = Color.Gray;
                else btn_X0E.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceX[(int)Module1X.cartridgeXAxisHome]) btn_X0F.BackColor = Color.Gray;
                else btn_X0F.BackColor = Color.YellowGreen;
                // 판넬
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.start]) btn_md1_X10.BackColor = Color.Gray;
                else btn_md1_X10.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.stop]) btn_md1_X11.BackColor = Color.Gray;
                else btn_md1_X11.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.emo]) btn_md1_X12.BackColor = Color.Gray;
                else btn_md1_X12.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.manual]) btn_md1_X13.BackColor = Color.Gray;
                else btn_md1_X13.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.auto]) btn_md1_X14.BackColor = Color.Gray;
                else btn_md1_X14.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DevicePanel[(int)ModulePanel.reset]) btn_md1_X15.BackColor = Color.Gray;
                else btn_md1_X15.BackColor = Color.YellowGreen;
                // Module1 Y입력
                if (!_plc1._plc1DeviceY[(int)Module1Y.md1_suppplyCylinderFWD]) btn_Y23.BackColor = Color.Gray;
                else btn_Y23.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceY[(int)Module1Y.md1_suppplyCylinderBWD]) btn_Y24.BackColor = Color.Gray;
                else btn_Y24.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceY[(int)Module1Y.md1_conveyorOnOff]) btn_Y28.BackColor = Color.Gray;
                else btn_Y28.BackColor = Color.YellowGreen;
                if (!_plc1._plc1DeviceY[(int)Module1Y.md1_CartredgeZAxisInterlock]) btn_Y29.BackColor = Color.Gray;
                else btn_Y29.BackColor = Color.YellowGreen;

                // Module2 입력
                if (!_plc2._plc2DeviceX[(int)Module2X.productCylinderFWD]) btn_md2_X01.BackColor = Color.Gray;
                else btn_md2_X01.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.productCylinderBWD]) btn_md2_X02.BackColor = Color.Gray;
                else btn_md2_X02.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.productSensor]) btn_md2_X03.BackColor = Color.Gray;
                else btn_md2_X03.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferCylinderLeft]) btn_md2_X04.BackColor = Color.Gray;
                else btn_md2_X04.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferCylinderRight]) btn_md2_X05.BackColor = Color.Gray;
                else btn_md2_X05.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferCylinderDown]) btn_md2_X06.BackColor = Color.Gray;
                else btn_md2_X06.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferCylinderUp]) btn_md2_X07.BackColor = Color.Gray;
                else btn_md2_X07.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferGrip]) btn_md2_X08.BackColor = Color.Gray;
                else btn_md2_X08.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.transferUnGrip]) btn_md2_X09.BackColor = Color.Gray;
                else btn_md2_X09.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.supplyCylinderCW]) btn_md2_X0A.BackColor = Color.Gray;
                else btn_md2_X0A.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.supplyCylinderCCW]) btn_md2_X0B.BackColor = Color.Gray;
                else btn_md2_X0B.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.supplyCylinderDown]) btn_md2_X0C.BackColor = Color.Gray;
                else btn_md2_X0C.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceX[(int)Module2X.supplyCylinderUp]) btn_md2_X0D.BackColor = Color.Gray;
                else btn_md2_X0D.BackColor = Color.YellowGreen;
                // 판넬
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.start]) btn_md2_X10.BackColor = Color.Gray;
                else btn_md2_X10.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.stop]) btn_md2_X11.BackColor = Color.Gray;
                else btn_md2_X11.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.emo]) btn_md2_X12.BackColor = Color.Gray;
                else btn_md2_X12.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.manual]) btn_md2_X13.BackColor = Color.Gray;
                else btn_md2_X13.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.auto]) btn_md2_X14.BackColor = Color.Gray;
                else btn_md2_X14.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DevicePanel[(int)ModulePanel.reset]) btn_md2_X15.BackColor = Color.Gray;
                else btn_md2_X15.BackColor = Color.YellowGreen;
                // Module2 Y입력
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_productCylinderFWD]) btn_md2_Y23.BackColor = Color.Gray;
                else btn_md2_Y23.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_productCylinderBWD]) btn_md2_Y24.BackColor = Color.Gray;
                else btn_md2_Y24.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_TransferCylinderRight]) btn_md2_Y25.BackColor = Color.Gray;
                else btn_md2_Y25.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_TransferCylinderLeft]) btn_md2_Y26.BackColor = Color.Gray;
                else btn_md2_Y26.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_TransferCylinderDown]) btn_md2_Y27.BackColor = Color.Gray;
                else btn_md2_Y27.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_TransferCylinderUp]) btn_md2_Y28.BackColor = Color.Gray;
                else btn_md2_Y28.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_TransferCylinderGripOnOff]) btn_md2_Y29.BackColor = Color.Gray;
                else btn_md2_Y29.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_supplyCylinderCW]) btn_md2_Y2A.BackColor = Color.Gray;
                else btn_md2_Y2A.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_supplyCylinderCCW]) btn_md2_Y2B.BackColor = Color.Gray;
                else btn_md2_Y2B.BackColor = Color.YellowGreen;
                if (!_plc2._plc2DeviceY[(int)Module2Y.md2_supplyCylinderUpDown]) btn_md2_Y2C.BackColor = Color.Gray;
                else btn_md2_Y2C.BackColor = Color.YellowGreen;

                Thread.Sleep(1000);
            }
        }

    }
}
