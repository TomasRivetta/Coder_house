from django.db import models

# Create your models here.
class Familia(models.Model):
    nombre = models.CharField(max_length=50)
    apellido = models.CharField(max_length=50)
    edad = models.IntegerField()
    fechaNacimiento = models.CharField(max_length=50)
    

class Mascota(models.Model):
    nombreMascota = models.CharField(max_length=50)
    raza = models.CharField(max_length=50)
    edadMascota = models.IntegerField()