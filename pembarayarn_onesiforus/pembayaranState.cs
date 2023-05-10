using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace pembarayarn_onesiforus
{
    public enum bayarState { BELUM_BAYAR, PENDING, VERIFIKASI, GAGAL, BERHASIL}
    public enum bayarTrigger { INPUT_PEMBAYARAN, CHECK_PEMBAYARAN, BALANCE, UNBALANCE }
    public class pembayaranState
    {
        bayarState statusAwal = bayarState.BELUM_BAYAR;
        public class Transition 
        {
            public bayarState statusAwal;
            public bayarState statusAkhir;
            public bayarTrigger aksi;
            public Transition(bayarState statusAwal, bayarState statusAkhir, bayarTrigger aksi) 
            {
                this.statusAwal = statusAwal;
                this.statusAkhir = statusAkhir;
                this.aksi = aksi;
            }
        }
        Transition[] transisi =
        {
            new Transition(bayarState.BELUM_BAYAR, bayarState.PENDING, bayarTrigger.INPUT_PEMBAYARAN),
            new Transition(bayarState.PENDING, bayarState.VERIFIKASI, bayarTrigger.CHECK_PEMBAYARAN),
            new Transition(bayarState.VERIFIKASI, bayarState.GAGAL, bayarTrigger.UNBALANCE),
            new Transition(bayarState.VERIFIKASI, bayarState.BERHASIL, bayarTrigger.BALANCE),
        };
        private bayarState GetNextState(bayarState statusAwal, bayarTrigger aksi) 
        {
            bayarState stateAkhir = statusAwal;
            for (int i = 0; i < transisi.Length; i++) 
            {
                Transition perubahan = transisi[i];
                if (statusAwal == perubahan.statusAwal && aksi == perubahan.aksi) 
                {
                    stateAkhir = perubahan.statusAkhir;
                }
            }
            return stateAkhir;
        }
        public void ActivateTrigger(bayarTrigger aksi) 
        {
            statusAwal = GetNextState(statusAwal, aksi);
            Console.WriteLine("Status Pembayaran sekarang adalah: " + statusAwal);
        }
    }
}
