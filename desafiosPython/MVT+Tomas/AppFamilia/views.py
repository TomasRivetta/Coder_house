from django.shortcuts import render
from django.http import HttpResponse
from django.template import Context, Template, loader
from .models import Familia, Mascota

# Create your views here.

def familia(request):

    listaNombre = ["Cesar","Elida","Geraldine","Tomas","Valentina","Catalina"]
    listaApellido = ["Rivetta","Mansicidor","Rivetta","Rivetta","Maldonado","Rivetta"]
    listaEdad = [49,46,24,19,19,4]
    listaFechaNacimiento = ["12/04/1973","24/04/1976","28/12/1997","16/05/2003","27/03/2003","03/05/2018"]
    listaFamilia = []

    for i in range(6):
        familia = Familia(nombre=listaNombre[i],apellido=listaApellido[i],edad=listaEdad[i], fechaNacimiento=listaFechaNacimiento[i])
        familia.save()
        texto = f"Familiar creado---> Nombre: {familia.nombre} || Apellido: {familia.apellido} || Edad: {familia.edad} años || Fecha de nacimiento: {familia.fechaNacimiento}"
        listaFamilia.append(texto)

    diccionario = {'lista': listaFamilia}

    plantilla = loader.get_template('template1.html')
    documento = plantilla.render(diccionario)

    return HttpResponse(documento)


def mascota(request):
    
    listaNombre = ["Cacho","Bianca","Mishi"]
    listaRaza = ["ovejero","caniche","Golden"]
    listaEdad = [8,9,5]
    listaMascotas = []

    for i in range(3):
        mascota = Mascota(nombreMascota=listaNombre[i],raza=listaRaza[i],edadMascota=listaEdad[i])
        mascota.save()
        texto = f"Mascota creada---> Nombre: {mascota.nombreMascota} || Raza: {mascota.raza} || Edad: {mascota.edadMascota} años"
        listaMascotas.append(texto)

    diccionarioMascota = {'listaMas': listaMascotas } 

    plantilla = loader.get_template('template2.html')
    documento = plantilla.render(diccionarioMascota)

    return HttpResponse(documento)
    