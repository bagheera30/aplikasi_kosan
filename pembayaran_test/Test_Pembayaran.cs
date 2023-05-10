using pembarayarn_onesiforus;

namespace pembayaran_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Metode_Pembayaran_Cash()
        {
            var config = new Config(metodePembayaran.E_WALLET, 6000);
            var pembayaran = new pembayaranconfig { config = config };

            // Act
            pembayaran.ubahMetode(2);

            // Assert
            Assert.AreEqual(pembayaran.config.metodePembayaran, metodePembayaran.CASH);
        }
        [TestMethod]

        public void biayaAdminTest_Cash()
        {
            // Arrange
            pembayaranconfig pc = new pembayaranconfig();
            int expected = 8000;

            // Act
            int actual = pc.biayaAdmin(metodePembayaran.CASH);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }

}