﻿using PptkNew.Entities;

namespace PptkNew.Models.Transaksi;

public class CreateDetailVM
{
#nullable disable
    public TransDetails TransDetail { get; set; }

    public long TransKegiatanId { get; set; }

#nullable enable
    public string? NamaRekening { get; set; } = String.Empty;
}