; --- Globals ---
Global MenuScale = 1
Global ButtonSFX

Function Min#(a#, b#)
	If a < b Then
		Return a
	Else
		Return b
	EndIf
End Function

; --- Button Function ---
Function Button%(x, y, width, height, txt$, disabled%=False)
    Local Pushed = False

    Color 50, 50, 50
    If Not disabled Then
        If MouseX() > x And MouseX() < x+width Then
            If MouseY() > y And MouseY() < y+height Then
                If MouseDown(1) Then
                    Pushed = True
                    Color 50*0.6, 50*0.6, 50*0.6
                Else
                    Color Min(50*1.2,255),Min(50*1.2,255),Min(50*1.2,255)
                EndIf
            EndIf
        EndIf
    EndIf

    If Pushed Then
        Rect x,y,width,height
        Color 133,130,125
        Rect x+1*MenuScale,y+1*MenuScale,width-1*MenuScale,height-1*MenuScale,False
        Color 10,10,10
        Rect x,y,width,height,False
        Color 250,250,250
        Line x,y+height-1*MenuScale,x+width-1*MenuScale,y+height-1*MenuScale
        Line x+width-1*MenuScale,y,x+width-1*MenuScale,y+height-1*MenuScale
    Else
        Rect x,y,width,height
        Color 133,130,125
        Rect x,y,width-1*MenuScale,height-1*MenuScale,False
        Color 250,250,250
        Rect x,y,width,height,False
        Color 10,10,10
        Line x,y+height-1,x+width-1,y+height-1
        Line x+width-1,y,x+width-1,y+height-1
    EndIf

    Color 255,255,255
    If disabled Then Color 70,70,70
    Text x+width/2, y+height/2-1*MenuScale, txt, True, True

    Color 0,0,0

    If Pushed And MouseHit(1) Then Return True
End Function

; --- Main ---
Graphics 800, 450, 0, 2

While Not KeyHit(1)
    ClsColor 200, 200, 200
    Cls
    
    Button 100, 100, 120, 30, "Click Me"
    Button 100, 150, 120, 30, "Disabled", True

    Flip true
Wend

End