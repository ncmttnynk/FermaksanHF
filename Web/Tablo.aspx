<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Tablo.aspx.cs" Inherits="Tablo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Kırtasiye Sanayi</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Sekreter Blokları</li>
                            <li><i class="fas fa-arrow-right"></i>Klasörler</li>
                            <li><i class="fas fa-arrow-right"></i>Mouse Pedler</li>
                            <li><i class="fas fa-arrow-right"></i>Kartvizit Albümü</li>
                            <li><i class="fas fa-arrow-right"></i>PVC Esaslı Kırtasiye Çeşitleri</li>
                        </ul>
                    </li>

                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Medikal Sanayi</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>İdrar Torbaları</li>
                            <li><i class="fas fa-arrow-right"></i>Lavman Torbaları</li>
                            <li><i class="fas fa-arrow-right"></i>Kan Torbaları</li>
                            <li><i class="fas fa-arrow-right"></i>Serum Setleri</li>
                            <li><i class="fas fa-arrow-right"></i>Havalı Yataklar</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Ambalaj Sanayi</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>PVC Ambalaj Sap ve Fermuar Baskı</li>
                            <li><i class="fas fa-arrow-right"></i>Küçük Boyutlu PVC Ambalaj Ürünleri</li>
                            <li><i class="fas fa-arrow-right"></i>Klişe Baskılar</li>
                            <li><i class="fas fa-arrow-right"></i>Serum Setleri</li>
                            <li><i class="fas fa-arrow-right"></i>Havalı Yataklar</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Promosyon Reklamcılık</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Ruhsat Kapları</li>
                            <li><i class="fas fa-arrow-right"></i>Ajanda Kapları</li>
                            <li><i class="fas fa-arrow-right"></i>Anahtarlık</li>
                            <li><i class="fas fa-arrow-right"></i>PVC Esaslı Tüm Promosyon Çeşitleri</li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <table class="table table-bordered center">
            <thead>
                <tr class="background-color-primary text-light">
                    <th>Teknik Tablo
                    </th>
                    <th>TR 40 S
                    </th>
                    <th>TR 40 MH
                    </th>
                    <th>TR 40 OH
                    </th>
                    <th>TR 40 DT
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr class="active">
                    <th scope="row" class="info">Alt Pleyt
                    </th>
                    <td class="primary">500 mm x 700 mm
                    </td>
                    <td colspan="2" class="center primary">300 mm x 700 mm
                    </td>
                    <td class="primary">450 mm x 600 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Üst Pleyt
                    </th>
                    <td colspan="4" class="info">250 mm x 350 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Tambur Çap
                    </th>
                    <td colspan="3" class="primary"></td>
                    <td class="primary center">1000-1500 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">İstasyon Sayısı
                    </th>
                    <td class="info" colspan="3"></td>
                    <td class="info center">4-6
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Çalışma Şekli
                    </th>
                    <td colspan="4" class="primary">Hidrolik & Pnömatik
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Silindir Çapı
                    </th>
                    <td class="info" colspan="4">Hidrolik: ø 63 mm & Pnömatik: ø 160 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Maksimum Strok
                    </th>
                    <td colspan="4" class="primary">150 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Jeneratör Çıkış Gücü
                    </th>
                    <td colspan="4" class="info">4 kVa
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Çalışma Gerilimi
                    </th>
                    <td colspan="4" class="primary">3 x 220 V 50 Hz
                    </td>

                </tr>
                <tr>
                    <th scope="row" class="primary">Gerilim Ayar Sahası
                    </th>
                    <td colspan="4" class="info">195 x 235 V
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Giriş Gücü
                    </th>
                    <td class="primary" colspan="4">
                    Hidrolik: 15 Kva & Pnömatik: 13 Kva
                </tr>
                <tr>
                    <th scope="row" class="primary">Osilatör Tipi
                    </th>
                    <td class="info" colspan="4">Lambalı
                    </td>

                </tr>
                <tr>
                    <th scope="row" class="info">Osilatör Soğutma
                    </th>
                    <td class="primary" colspan="4">Hava ile soğutma
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Doğrultma
                    </th>
                    <td class="info" colspan="4">Silikon Diyot
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Frekans
                    </th>
                    <td class="primary" colspan="4">27.12 Mhz ±1%
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Ağırlık
                    </th>
                    <td class="info">430 Kg
                    </td>
                    <td class="info">505 Kg
                    </td>
                    <td class="info">650 Kg
                    </td>
                    <td class="info">910 Kg
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Makina Ebatları
                    </th>
                    <td class="primary">700x1500x1600 mm
                    </td>
                    <td class="primary">2200x1500x1600 mm
                    </td>
                    <td class="primary">2400x1500x1600 mm
                    </td>
                    <td class="primary">1700x2500x1600mm
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <hr />
    <div class="container">
        <table class="table table-bordered center">
            <thead>
                <tr class="background-color-primary text-light">
                    <th>Technical Details
                    </th>
                    <th>TR 40 S
                    </th>
                    <th>TR 40 MH
                    </th>
                    <th>TR 40 OH
                    </th>
                    <th>TR 40 DT
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr class="active">
                    <th scope="row" class="info">Bottom Plate
                    </th>
                    <td class="primary">500 mm x 700 mm
                    </td>
                    <td colspan="2" class="center primary">300 mm x 700 mm
                    </td>
                    <td class="primary">450 mm x 600 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Top Plate
                    </th>
                    <td colspan="4" class="info">250 mm x 350 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Drum Diameter
                    </th>
                    <td colspan="3" class="primary"></td>
                    <td class="primary center">1000-1500 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">İstasyon Sayısı
                    </th>
                    <td class="info" colspan="3"></td>
                    <td class="info center">4-6
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Working Principle
                    </th>
                    <td colspan="4" class="primary">Hydraulic & Pneumatic
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Cylinder Diameter
                    </th>
                    <td class="info" colspan="4">Hydraulic: ø 63 mm & Pneumatic: ø 160 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Maximum Strok
                    </th>
                    <td colspan="4" class="primary">150 mm
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Output Power Of Generator
                    </th>
                    <td colspan="4" class="info">4 kVa
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Operating Voltage
                    </th>
                    <td colspan="4" class="primary">3 x 220 V 50 Hz
                    </td>

                </tr>
                <tr>
                    <th scope="row" class="primary">Voltage Fixing RangeSahası
                    </th>
                    <td colspan="4" class="info">195 x 235 V
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Input Power
                    </th>
                    <td class="primary" colspan="4">
                    Hydraulic: 15 Kva & Pneumatic: 13 Kva
                </tr>
                <tr>
                    <th scope="row" class="primary">Oscillator Type
                    </th>
                    <td class="info" colspan="4">Lambalı
                    </td>

                </tr>
                <tr>
                    <th scope="row" class="info">Oscillator Cooling
                    </th>
                    <td class="primary" colspan="4">With Air Cooling
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Correction
                    </th>
                    <td class="info" colspan="4">Silicon Diode
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Frequency
                    </th>
                    <td class="primary" colspan="4">27.12 Mhz ±1%
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="primary">Weight
                    </th>
                    <td class="info">430 Kg
                    </td>
                    <td class="info">505 Kg
                    </td>
                    <td class="info">650 Kg
                    </td>
                    <td class="info">910 Kg
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="info">Machine Dimensions
                    </th>
                    <td class="primary">700x1500x1600 mm
                    </td>
                    <td class="primary">2200x1500x1600 mm
                    </td>
                    <td class="primary">2400x1500x1600 mm
                    </td>
                    <td class="primary">1700x2500x1600mm
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Stationary Industry</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Business Card Albums</li>
                            <li><i class="fas fa-arrow-right"></i>Mouse Pads</li>
                            <li><i class="fas fa-arrow-right"></i>Pocket Agendas</li>
                            <li><i class="fas fa-arrow-right"></i>All PVC Based Stationery and Promotion Assortmens</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Medical Industry</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Urine Bags</li>
                            <li><i class="fas fa-arrow-right"></i>Enema Bags</li>
                            <li><i class="fas fa-arrow-right"></i>Serum Sets</li>
                            <li><i class="fas fa-arrow-right"></i>Blood Bags</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Packaging Industry</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Tricot Clothing Packaging</li>
                            <li><i class="fas fa-arrow-right"></i>Socks Packaging</li>
                            <li><i class="fas fa-arrow-right"></i>Blister Pack</li>
                            <li><i class="fas fa-arrow-right"></i>All PVC Based Packaging Assortmens</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="col-md-3 background-color-primary text-light">
                <ul class="list list-icons list-icons-style-3 list-borders">
                    <li><i class="fas fa-arrow-right"></i><strong>Promotion and Advertising</strong>
                        <ul class="list list-icons list-icons-style-3 list-icon-sm list-borders">
                            <li><i class="fas fa-arrow-right"></i>Licence Plates and Dishes</li>
                            <li><i class="fas fa-arrow-right"></i>Calender Utensils</li>
                            <li><i class="fas fa-arrow-right"></i>Key chains</li>
                            <li><i class="fas fa-arrow-right"></i>PVC Based All Promotional Varieties</li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <table class="table table-bordered center">
            <thead>
                <tr class="background-color-primary text-light">
                    <th>Technical Details</th>
                    <th>TR 250 B</th>
                </tr>
            </thead>
            <tbody>
                <tr class="active">
                    <th class="info" scope="row">Bottom Platte</th>
                    <td class="primary">400 mm x 1400 mm</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Top Platte</th>
                    <td class="info">280 mm x 1100 mm</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Working Principle</th>
                    <td class="primary center">Hydraulic</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Maximum Strok</th>
                    <td class="info">100 mm</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Output Power of Generator</th>
                    <td class="primary">15, 20, 25, 30 kVa</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Operating Voltage</th>
                    <td class="info">3 x 220 V 50 Hz</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Voltage Fixing Range</th>
                    <td class="primary">195 x 235 V</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Input Power</th>
                    <td class="info">Hydraulic: 38 kVa</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Oscillator Type</th>
                    <td class="primary">Lamp</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Oscillator Cooling</th>
                    <td class="info">With Air Cooling</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Correction</th>
                    <td class="primary">Silicon Diode</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Frequency</th>
                    <td class="info" colspan="4">27.12 Mhz ±1%</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Weight</th>
                    <td class="primary">2.000 Kg</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Machine Dimensions</th>
                    <td class="info">1000x2900x2400 mm</td>
                </tr>
            </tbody>
        </table>
    </div>
    <hr />
    <div class="container">
        <table class="table table-bordered center">
            <thead>
                <tr class="background-color-primary text-light">
                    <th>Teknik Tablo</th>
                    <th>TR 250 SB</th>
                </tr>
            </thead>
            <tbody>
                <tr class="active">
                    <th class="info" scope="row">Üst Pleyt</th>
                    <td class="primary">500 mm x 800 mm</td>
                </tr>
                  <tr>
                    <th class="primary" scope="row">Üst Pleyt</th>
                    <td class="info">200 mm x 600 mm</td>
                </tr>
                 <tr class="active">
                    <th class="info" scope="row">Boğaz Derinliği</th>
                    <td class="primary">500 mm, 900 mm (isteğe göre)</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Çalışma Şekli</th>
                    <td class="info">Hidrolik & Pnömatik</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Silindir Çapı</th>
                    <td class="primary center">Hidrolik: ø 63 mm & Pnömatik: ø 63 mm </td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Maksimum Vuruş</th>
                    <td class="info">100 mm</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Jeneratör Çıkış Gücü</th>
                    <td class="primary">15, 20, 25, 0 kVa</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Çalışma Gerilimi</th>
                    <td class="info">3 x 220 V 50 Hz</td>
                </tr>
                <tr>
                    <th class="info" scope="row">Gerilim Ayar Sahası</th>
                    <td class="primary">195 x 235 V</td>
                </tr>
                <tr>
                    <th class="primary" scope="row">Giriş Gücü</th>
                    <td class="info">Hidrolik: 38 kVa & Pnömatik: 35 kVa</td>
                </tr>
                 <tr>
                    <th class="info" scope="row">Osilatör Tipi</th>
                    <td class="primary">Lambalı</td>
                </tr>
                 <tr>
                    <th class="primary" scope="row">Osilatör Soğutma</th>
                    <td class="info">Hava ile Soğutma</td>
                </tr>
                 <tr>
                    <th class="info" scope="row">Doğrultma</th>
                    <td class="primary">Silikon Diyot</td>
                </tr>
                  <tr>
                    <th class="primary" scope="row">Frekans</th>
                    <td class="info">27.12 Mhz ±1%</td>
                </tr>
                 <tr>
                    <th class="info" scope="row">Ağırlık</th>
                    <td class="primary">1.100 Kg</td>
                </tr>
                 <tr>
                    <th class="primary" scope="row">Makina Ebatları</th>
                    <td class="info">900 mm x 2000 mm x 2400 mm</td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>

