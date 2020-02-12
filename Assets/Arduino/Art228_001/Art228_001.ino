int ledPin = 13; 
int inPin1 = 8;   
int inPin2 = 9;   
int inPin3 = 10;   
int inPin4 = 11;   
int val1 = 0;  
int val2 = 0;
int val3 = 0;
int val4 = 0;
int lastSendData = 0;

void setup()
{
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  pinMode(inPin1, INPUT);
  pinMode(inPin2, INPUT);
  pinMode(inPin3, INPUT);
  pinMode(inPin4, INPUT);
}

void loop()
{
  delay(50);
  
  val1 = digitalRead(inPin1);
  val2 = digitalRead(inPin2);
  val3 = digitalRead(inPin3);
  val4 = digitalRead(inPin4);
/*
  Serial.print("VAL=");
  Serial.print(val1, DEC);
  Serial.print(val2, DEC);
  Serial.print(val3, DEC);
  Serial.println(val4, DEC);

  digitalWrite(ledPin, val1);
*/

  if(val1 == 1) {
     if(lastSendData != 1) {
        //Serial.write(1);
        //Serial.println(1, DEC);
        Serial.println("1");
        lastSendData = 1;
        return;
      }
  }
  if(val2 == 1) {
      if(lastSendData != 2) {
        //Serial.write(2);
        //Serial.println(2, DEC);
        Serial.println("2");
        lastSendData = 2;
        return;
      }
  }
  if(val3 == 1) {
      if(lastSendData != 3) {
        //Serial.write(3);
        //Serial.println(3, DEC);
        Serial.println("3");
        lastSendData = 3;
        return;
      } 
  }
  if(val4 == 1) {
      if(lastSendData != 4) {
        //Serial.write(4);
        //Serial.println(4, DEC);
        Serial.println("4");
        lastSendData = 4;
        return;
      }
  }
}
