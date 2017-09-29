<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kontakt.aspx.cs" Inherits="PlagijatorFinder.Kontakt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type ="text/css">
        
        #map{
            width: 60%;
            float:right;            
        }
        #adr{            
            width: 20%;
            font-size: 50;  
            margin-bottom: 10px;          
        }
        #fb{
            float:left;
        }
        
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <iframe id="fb" src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fmatematicki.fakultet%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=true&appId" width="340" height="500" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true"></iframe>
    
    <iframe ID="map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2362.7107612694444!2d20.45700379852957!3d44.81926143888125!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x475a7ab4a72f8975%3A0x7c9c68a37ad79aad!2sUniverzitet+u+Beogradu+-+Matemati%C4%8Dki+fakultet!5e0!3m2!1sen!2srs!4v1506695034802" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
    
</asp:Content>
