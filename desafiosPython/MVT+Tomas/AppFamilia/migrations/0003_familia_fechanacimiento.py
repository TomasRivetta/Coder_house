# Generated by Django 4.1 on 2022-08-19 00:25

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('AppFamilia', '0002_remove_familia_fechadenacimiento'),
    ]

    operations = [
        migrations.AddField(
            model_name='familia',
            name='fechaNacimiento',
            field=models.CharField(default=1, max_length=50),
            preserve_default=False,
        ),
    ]
