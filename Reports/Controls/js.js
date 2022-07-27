var isFocus = false;
var bStop;

function getNum(num)
{
	switch(num)
	{
		case "0":	return "1,1,1||1,1|1,0,1|1,1";
		case "1":	return "1,1,1||0,0|0,0,0|1,1";
		case "2":	return "1,1,1||0,1|1,1,1|1,0";
		case "3":	return "1,1,1||0,0|1,1,1|1,1";
		case "4":	return "1,1,1||1,0|0,1,0|1,1";
		case "5":	return "1,1,1||1,0|1,1,1|0,1";
		case "6":	return "1,1,1||1,1|1,1,1|0,1";
		case "7":	return "1,1,1||1,0|1,0,0|1,1";
		case "8":	return "1,1,1||1,1|1,1,1|1,1";
		case "9":	return "1,1,1||1,0|1,1,1|1,1";
		case ".":	return "0,1,0||0,0|0,0,1|0,0";	
		case "-":	return "0,1,0||0,0|0,1,0|0,0";
		case "E":	return "1,1,1||1,1|1,1,1|0,0";
		case "r":	return "1,1,1||1,1|1,0,0|1,0";
	}
	
	return false;
}

function showNum(num)
{
	var arr = new Array();
	var out = "",i;
	var ePos,nPow;

	ePos = num.indexOf("e")
	if(ePos != (-1))
	{
		nPow = num.substring(ePos+2,num.length);
		num = num.substring(0,ePos);
		pow1.style.display = "block";
		pow2.innerText = " " + nPow;
	}
	
	for(i=0;i<num.length;i++)
	{
		
		dig = num.substring(i,i+1);
		
		dig = getNum(dig);

		if(dig)
		{
			dig = dig.replace("||",",");
			dig = dig.replace(/[|]/g,",");
			
			arr = dig.split(",");
			
			out += '<td class="num" height="100%">';
			out += '	<table cellpadding="0" cellspacing="0" height="100%">';
			out += '		<Tr>';
			out += '			<td class="normal' + arr[0] + '">';
			out += '				<table cellpadding="0" cellspacing="0">';
			out += '					<tr><td class="ver' + arr[3] + '"><div></div></td></tr>';
			out += '					<tr><td class="ver' + arr[4] + '"><div></div></td></tr>';
			out += '				</table>';
			out += '			</td>';
			out += '			<td class="normal' + arr[1] + '" height="100%">';
			out += '				<table cellpadding="0" cellspacing="0" height="100%">';
			out += '					<tr><td class="hor' + arr[5] + '" valign="top"><div></div></td></tr>';
			out += '					<tr><td class="hor' + arr[6] + '"><div></div></td></tr>';
			out += '					<tr><td class="hor' + arr[7] + '" valign="bottom"><div></div></td></tr>';
			out += '				</table>';
			out += '			</td>';
			out += '			<td class="normal' + arr[2] + '">';
			out += '				<table cellpadding="0" cellspacing="0">';
			out += '					<tr><td class="ver' + arr[8] + '"><div></div></td></tr>';
			out += '					<tr><td class="ver' + arr[9] + '"><div></div></td></tr>';
			out += '				</table>';
			out += '			</td>';
			out += '		</tr>';
			out += '	</table>';
			out += '</td>';
		}
	}
	
	nums.innerHTML = '<table cellpadding="0" cellspacing="0"><tr>' + out + "</tr></table>";
}

function calc(str)
{
	var result;
	
	pow1.style.display = "none";

	try
	{
		if(str==null || str=="")	str = "0";
		eval('result = ' + str + ';');

		if(result=="Infinity")
			showNum("Err0r");
		else
			eval('showNum("' + result + '");');
	}
	catch(e)
	{
		showNum("Err0r");
	}
	
}
function AddChr(chr,place)
{
	if(place == "before")
		frmCalc.num.value = chr + frmCalc.num.value;
	else
		frmCalc.num.value += chr;
}
function DEL()
{
	frmCalc.num.value = frmCalc.num.value.substring(0,frmCalc.num.value.length-1);
}
function AC()
{
	frmCalc.num.value = "";
	calc();
	divScreen.scrollLeft = 0;
	frmCalc.num.style.paddingLeft = 0;
}
function manKeys(key)
{
	if(!isFocus)
		switch(key)
		{
			case 48:
				if(event.shiftKey==true)
					AddChr(")","after");
				else
					AddChr("0","after");
				break;
			case 96:	
				AddChr("0","after");
				break;
			case 49:
			case 97:	
				AddChr("1","after");
				break;
			case 50:
			case 98:	
				AddChr("2","after");
				break;
			case 51:
			case 99:	
				AddChr("3","after");
				break;
			case 52:
			case 100:	
				AddChr("4","after");
				break;
			case 53:
			case 101:	
				AddChr("5","after");
				break;
			case 54:
			case 102:	
				AddChr("6","after");
				break;
			case 55:
			case 103:	
				AddChr("7","after");
				break;
			case 56:
			case 104:	
				AddChr("8","after");
				if(event.shiftKey==true)AddChr("*","after");
				break;
			case 57:
				if(event.shiftKey==true)
					AddChr("(","after");
				else
					AddChr("9","after");
				break;
			case 105:	
				AddChr("9","after");
				break;
			
			case 107:	
				AddChr("+","after");
				break;
			case 187:	
				if(event.shiftKey==true)AddChr("+","after");
				break;
			
			case 109:	
				AddChr("-","after");
				break;
			case 189:	
				if(event.shiftKey==false)
					AddChr("-","after");
				break;
			
			case 106:
				AddChr("*","after");
				break;
			
			case 111:
				AddChr("/","after");
				break;
			case 220:
				if(event.shiftKey==false)
					AddChr("/","after");
				break;

			case 8:
				DEL();
				break;				
		
		}
		
		switch(key)
		{
			case 13:
				calc(frmCalc.num.value);
				break;
			
			case 27:
				AC();
				break;
				
			case 37:
			case 39:
				MoveScreen(key);
				break;
		}
}

function MoveScreen(key)
{
	var mount;

	if(key == 37)	mount = -10;
	if(key == 39)	mount = 10;
	
	divScreen.scrollLeft += mount;
	frmCalc.num.style.paddingLeft = divScreen.scrollLeft;
}

function actSelected(act)
{
	var obj = frmCalc.num;
	var sText,HM;
	
	if(obj.createTextRange)
	{
		obj.focus(obj.caretPos);
		obj.caretPos = document.selection.createRange().duplicate();
		sText = obj.caretPos.text;
		HM = HowMany(act,"#");
		obj.caretPos.text = act.replace(/[#]/g,sText);
		obj.caretPos.moveStart("character",(act.length * -1) + HM - (sText.length*HM));
		obj.caretPos.select();
	}
}

function HowMany(sText,subStr)
{
	var temp_len;
	var count=-1;

	do
	{
		count++;
		temp_len = sText.length;
		sText = sText.replace(subStr,"");
	}
	while(temp_len > sText.length)
	
	return count;
}