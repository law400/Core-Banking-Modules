<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calculator.aspx.vb" Inherits="Calculator" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html>
	<head>
		<title>Calc</title>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1255">
		<LINK REL="StyleSheet" HREF="style.css" TYPE="text/css">
		<script language="javascript" type="text/javascript" src="js.js"></script>
	</head>
	<body onload="calc()" onkeydown="manKeys(event.keyCode)">
		<form name="frmCalc" onsubmit="return(false);">
			<table cellpadding="0" cellspacing="0" class="main_table" align="left">
				<Tr>
					<Td class="calc_header">
						<table cellpadding="0" cellspacing="0" width="100%">
							<Tr>
								<Td><span class="comany_name"">PRIME Calculator</span></Td>
								<td align="right">&nbsp;</td>
							</Tr>
							<Tr>
								<td colspan="2" align="center"><br>
									<br>
									</td>
							</Tr>
						</table>
					</Td>
				</Tr>
				<TR>
					<Td valign="top" align="center">
						<div id="divScreen" class="calc_table_div" align="center">
							<table cellpadding="0" cellspacing="0" class="calc_table">
								<tr>
									<Td colspan="2" align="center"><input type="text" name="num" class="TextBox" onfocus="javascript:isFocus=true;" onblur="javascript:isFocus=false;"></Td>
								</tr>
								<tr>
									<td id="nums" valign="top" align="right" onselectstart="num.focus();" onclick="num.focus();"></td>
									<Td class="pow" id="pow1" nowrap onselectstart="return(false)" onclick="num.focus();">
										x10<sup id="pow2">2</sup>
									</Td>
								</tr>
							</table>
						</div>
					</Td>
				</TR>
				<Tr>
					<td style="height:100%;" valign="top">
						<table width="100%" style="height:100%;">
							<tr>
								<Td class="black_buttons" align="center">
									<input type="button" value="Abs" class="black_button" onclick="actSelected('Math.abs(#)');document.body.focus();">
									<input type="button" value="Acos" class="black_button" onclick="actSelected('Math.acos(#)');document.body.focus();">
									<input type="button" value="Asin" class="black_button" onclick="actSelected('Math.asin(#)');document.body.focus();">
									<input type="button" value="Atan" class="black_button" onclick="actSelected('Math.atan(#)');document.body.focus();">
									<input type="button" value="Ceil" class="black_button" onclick="actSelected('Math.ceil(#)');document.body.focus();">
									<input type="button" value="Cos" class="black_button" onclick="actSelected('Math.cos(#)');document.body.focus();">
								</Td>
							</tr>
							<tr>
								<Td class="black_buttons" align="center">
									<input type="button" value="Exp" class="black_button" onclick="actSelected('Math.exp(#)');document.body.focus();">
									<input type="button" value="Floor" class="black_button" onclick="actSelected('Math.floor(#)');document.body.focus();">
									<input type="button" value="Log" class="black_button" onclick="actSelected('Math.log(#)');document.body.focus();">
									<input type="button" value="Pow" class="black_button" onclick="actSelected('Math.pow(#,#)');document.body.focus();">
									<input type="button" value="Rnd" class="black_button" onclick="actSelected('Math.round(#)');document.body.focus();">
									<input type="button" value="Sin" class="black_button" onclick="actSelected('Math.sin(#)');document.body.focus();">
								</Td>
							</tr>
							<tr>
								<Td class="black_buttons" align="center">
									<input type="button" value="Sqr" class="black_button" onclick="actSelected('Math.sqrt(#)');document.body.focus();">
									<input type="button" value="Tan" class="black_button" onclick="actSelected('Math.tan(#)');document.body.focus();">
									<input type="button" value="Max" class="black_button" onclick="actSelected('Math.max(#,)');document.body.focus();">
									<input type="button" value="Min" class="black_button" onclick="actSelected('Math.min(#,)');document.body.focus();">
									<input type="button" value="Atan2" class="black_button" onclick="actSelected('Math.atan2(#,)');document.body.focus();">
									<input type="button" value="PI" class="black_button" onclick="actSelected('Math.PI');document.body.focus();">
								</Td>
							</tr>
							<tr>
								<Td class="black_buttons" align="center">
									<input type="button" value="(" class="black_button" onclick="AddChr('(','after');document.body.focus();">
									<input type="button" value=")" class="black_button" onclick="AddChr(')','after');document.body.focus();">
									<input type="button" value="NOT" class="black_button" onclick="actSelected('# ~');document.body.focus();">
									<input type="button" value="OR" class="black_button" onclick="actSelected('# |');document.body.focus();">
									<input type="button" value="AND" class="black_button" onclick="actSelected('# &');document.body.focus();">
									<input type="button" value="XOR" class="black_button" onclick="actSelected('# ^');document.body.focus();">
								</Td>
							</tr>
							<tr>
								<Td class="normal_buttons" valign="bottom" style="height:100%;">
									<table width="100%">
										<Tr>
											<td class="buttons_space"><span class="span_button"><input type="button" value="7" class="gray_button" onclick="AddChr('7','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="8" class="gray_button" onclick="AddChr('8','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="9" class="gray_button" onclick="AddChr('9','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="DEL" class="red_button" onclick="DEL();document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="AC" class="red_button" onclick="AC();document.body.focus();"></span></td>
										</Tr>
										<Tr>
											<td class="buttons_space"><span class="span_button"><input type="button" value="4" class="gray_button" onclick="AddChr('4','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="5" class="gray_button" onclick="AddChr('5','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="6" class="gray_button" onclick="AddChr('6','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="X" class="gray_button" onclick="AddChr('*','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="?" class="gray_button" onclick="AddChr('/','after');document.body.focus();"></span></td>
										</Tr>
										<Tr>
											<td class="buttons_space"><span class="span_button"><input type="button" value="1" class="gray_button" onclick="AddChr('1','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="2" class="gray_button" onclick="AddChr('2','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="3" class="gray_button" onclick="AddChr('3','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="+" class="gray_button" onclick="AddChr('+','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="&#151;" class="gray_button" onclick="AddChr('-','after');document.body.focus();"></span></td>
										</Tr>
										<Tr>
											<td class="buttons_space"><span class="span_button"><input type="button" value="0" class="gray_button" onclick="AddChr('0','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="." class="gray_button" onclick="AddChr('.','after');document.body.focus();"></span></td>
											<td class="buttons_space"><span class="span_button"><input type="button" value="-" class="gray_button" onclick="AddChr('-','after');document.body.focus();"></span></td>
											<td colspan="2" class="buttons_space"><span class="span_button"><input type="button" value="=" class="gray_button" onclick="calc(frmCalc.num.value);document.body.focus();"
														style="width:127px;"></span></td>
										</Tr>
									</table>
								</Td>
							</tr>
						</table>
					</td>
				</Tr>
			</table>
		</form>
	</body>
</html>
