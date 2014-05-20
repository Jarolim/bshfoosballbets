<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FoozballBets._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

	<h1>Welcome to the BSH Betting Website</h1>

	<asp:ListView ID="lvCurrentPoll" runat="server" ItemType="FoozballBets.Models.ProfilesBSH">
		
		<ItemTemplate>

			<%--<script>
				for (var i = 0; i < <%# Items.Count %>; i++) {
					$('#itemNumber').text(i);
				};
			</script>--%>
			<div>
				<img src="<%# Item.ProfilePicPath %>" alt="Alternate Text" style="width:20px; height:20px;" />
				<span><%# Container.DataItemIndex + 1 %> <%# Item.Name %> Points: <%# Item.Points %></span>
			</div>
		</ItemTemplate>
	</asp:ListView>


	

</asp:Content>
