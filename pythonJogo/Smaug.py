import pygame, sys
from pygame.locals import *
import threading
import random
import time


def main():
	
	pygame.init()
	global DISPLAY, largura, altura, relogio, FPS, estado, vida, vidas,  numNave, naveF, naveD, naveE, x, y, xNav, yNav, cinza, naveAlt, naveLar, objetoStartx, objetoStarty, objetoVel,\
	objetoAlt, objetoLar, velX, velY, asteroide, desvios, balaAlt, balaLar, balaX, balaY, muni, tiroVisivel, fundoMenu, iniciarMenu, sairMenu, configMenu, mouseX, mouseY, bkground, fundo_Y,\
	iniciarMenu_I, configMenu_I, sairMenu_I, xbonus, ybonus, bonusLar, bonusLar, bonuAlt, vidas2, vidas3
	pygame.font.init()


	global ponto
	ponto = 0
	vida = 3
	
	tiroVisivel = False
	#estado  = "menu"

	largura = 800			#variavel para largura e altura da tela do jogo
	altura = 600

	DISPLAY = pygame.display.set_mode((largura, altura))	#setando a tela do jogo
	pygame.display.set_caption("Nave Race")				#nome do jogo mostrado no centro da margem

	x = 500
	y = 200
	yNav = y - 5
	xNav = x + 40
	velX = 0			#setando a velocidade que será utilizada na nave
	velY = 0
	cinza = (100, 100, 100)
	naveLar = 100		#largura da nave
	naveAlt = 160		#altura da nave
	


	#carregando as imagens da nave e o retangulo "invisivel" que ficará em volta da nave para coisões
	
	
	nave = Rect((x,y),(naveLar,naveAlt))
	tiro = Rect((xNav,yNav),(10,20))
	naveFrente = pygame.image.load("frente.jpeg")
	naveDireito = pygame.image.load("Ldireito.jpeg")
	naveEsquerdo = pygame.image.load("lEsquerdo.jpeg")
	meteoro = pygame.image.load("Meteoro.jpeg")
	fundoMenu = pygame.image.load("fundomenu.jpeg")
	iniciarMenu = pygame.image.load("iniciar.jpeg")
	configMenu = pygame.image.load("configuracoes.jpeg")
	sairMenu = pygame.image.load("sair.jpeg")
	naveF = pygame.transform.scale(naveFrente,(100, 160))
	naveD = pygame.transform.scale(naveDireito,(100, 160))		#alterando o tamanho da imagem
	naveE = pygame.transform.scale(naveEsquerdo,(100, 160))
	asteroide = pygame.transform.scale(meteoro,(100, 160))
	fundoMenu = pygame.transform.scale(fundoMenu,(largura, altura))
	iniciarMenu = pygame.transform.scale(iniciarMenu,(300, 80))
	iniciarMenu_I = pygame.transform.scale(iniciarMenu, (305, 85))
	configMenu = pygame.transform.scale(configMenu, (300, 80))
	configMenu_I = pygame.transform.scale(configMenu, (305, 85))
	sairMenu = pygame.transform.scale(sairMenu, (300, 80))
	sairMenu_I = pygame.transform.scale(sairMenu, (305, 85))
	vidas = Rect((largura - 40, altura - 580),(20, 20))
	vidas2 = Rect((largura - 70, altura - 580),(20, 20))
	vidas3 = Rect((largura - 100, altura - 580),(20, 20))
	bkground = pygame.image.load("bkground.jpeg")
	bkground = pygame.transform.scale(bkground, (largura, altura))
	relogio = pygame.time.Clock()
	

	FPS=30

	numNave = 0

	objetoStartx = random.randrange(0, largura)		#setando posições aleatórias de inicio dos objetos de colisao
	objetoStarty = -600
	objetoVel = 15			#velocidade do objeto de colisão
	objetoLar = 100			#largura e altura dos objetos
	objetoAlt = 100

	desvios = 0
	
	
	
	xbonus = random.randrange(0, largura)
	ybonus = -100
	bonusLar = 30
	bonuAlt = 30
	
	
	while True:
		menu()
		relogio.tick(FPS)
		pygame.display.update()
		
		
def objetosDesviar(contador):
	font = pygame.font.SysFont(None, 25)
	text = font.render("Desvios:" +str(contador), True, cinza)
	
	textPonto = font.render("Pontos: " + str(ponto), True, cinza)
	DISPLAY.blit(text,(0,0))
	DISPLAY. blit(textPonto,(0, 30))


def text_objects(text, font):
	textSurface = font.render(text, True, cinza)
	return textSurface, textSurface.get_rect()

def mensagem_display(text):
	textoGrande = pygame.font.Font('freesansbold.ttf',115)
	TextSurf, TextRect = text_objects(text, textoGrande)
	TextRect.center = ((largura/2), (altura/2))
	DISPLAY.blit(TextSurf, TextRect)

	pygame.display.update()

	time.sleep(2)

	#game_loop()

def bateu():
	DISPLAY.fill((255, 255, 255))
	mensagem_display("Voce bateu")


def objetos(objetoX, objetoY, objetoLar, objetoAlt, color):			#função para criar os objetos de colisão aleatórios
	
	#pygame.draw.rect(DISPLAY, color, [objetoX, objetoY, objetoLar, objetoAlt])	#desenhando os objetos de colisão
	DISPLAY.blit(asteroide,(objetoX, objetoY))
	
	
	
	
	
def balas(bx, by, bLar, bAlt):
	muni = Rect((bx, by), (bLar, bAlt))
	if tiroVisivel == True:
		pygame.draw.rect(DISPLAY,(255, 255, 0), muni)
	
	
	
def bon(bonx,bony, bonar, bonalt):
	global bonus
	bonus = Rect(( bonx, bony), (bonar, bonalt))
		
	




#def game_loop():
#	global x, y
#	x = (largura * 0.45)
#	y = (altura * 0.8)




def menu():
	DISPLAY.blit(fundoMenu,(0, 0))
	#DISPLAY.blit(iniciarMenu,(270, 200))
	#DISPLAY.blit(configMenu,(270, 300))
	#DISPLAY.blit(sairMenu, (270, 400))

	back = True
	while back:
		mouseX, mouseY = pygame.mouse.get_pos()
		xx = 270
		yy = 200
		for e in pygame.event.get():
			if e.type==QUIT:
					back = False
					sys.exit()

			if e.type == pygame.MOUSEBUTTONDOWN:
				if (mouseX >= 270 and mouseX <= 570) and (mouseY >= 200 and mouseY <= 280):

					jogando()
				elif(mouseX >= 270 and mouseX <= 570) and (mouseY >= 300 and mouseY <= 380):
					print("x")
				elif(mouseX >= 270 and mouseX <= 570) and (mouseY >= 400 and mouseY <= 480):
					print('x')


			if e.type == pygame.MOUSEMOTION:
					if (mouseX >= 270 and mouseX <= 570) and (mouseY >= 200 and mouseY <= 280):
						DISPLAY.blit(iniciarMenu_I, (268, 198))
				
		
					elif(mouseX >= 270 and mouseX <= 570) and (mouseY >= 300 and mouseY <= 380):
						DISPLAY.blit(configMenu_I, (268, 298))
						

					elif(mouseX >= 270 and mouseX <= 570) and (mouseY >= 400 and mouseY <= 480):
						DISPLAY.blit(sairMenu_I, (268, 398))
						
					else:
						DISPLAY.blit(configMenu, (270, 300))
						DISPLAY.blit(iniciarMenu, (270, 200))
						DISPLAY.blit(sairMenu, (270, 400))


		relogio.tick(FPS)
		pygame.display.update()

	pygame.quit()
		
	
	#pygame.quit()
	
	
	
	

		

	
			
		#sair = False

def jogando():
	global estado, vida, numNave, x, y, objetoStartx, objetoStarty, objetoAlt, velX, velY, desvios, yNav, xNav, balaX, balaY, balaLar, balaAlt, tiroVisivel, seguir, bx, by,ponto, bonus, xbonus, ybonus,\
	bonuAlt, bonusLar, acelerarNave, bonusEscolha, bonusVisivel
	
	seguir = True
	acelerarNave= 8
	bonusVisivel = False
	
	
	fundo_Y = 0
	
	
	sair = True
	while sair:
		
	
	
		fundo = fundo_Y % 600
		DISPLAY.blit(bkground, (0, fundo - 600))
		
		if fundo < altura:
			DISPLAY.blit(bkground, (0, fundo))
		
		
		fundo_Y += 3


		

		#pygame.display.update()

		if  seguir == True:
			balaX = x + 45
			balaY = y 
			balaLar = 10
			balaAlt = 10
		
		

		
		#pygame.draw.rect(DISPLAY,( 0, 0, 0), nave)		#este item que estava criando o bloco preto
		
		if (vida > 1):
			pygame.draw.rect(DISPLAY, (255, 0,0), vidas)
			
		if (vida > 2):
			pygame.draw.rect(DISPLAY, (255, 0,0), vidas2)
			
		if (vida > 3):
			pygame.draw.rect(DISPLAY, (255, 0,0), vidas3)
		
		
		
		
		if (numNave == 1):
			DISPLAY.blit(naveD,(x,y))

		elif(numNave == 2):
			DISPLAY.blit(naveE,(x,y))

		elif(numNave == 0):
			DISPLAY.blit(naveF,(x,y))


		if x > largura -naveLar or x < 0:		#definindo o limite das margens da tela
			velX = 0
		if y > altura - naveAlt or y < 0:
			velY = 0

		if objetoStarty > altura:
			objetoStarty = 0 - objetoAlt
			objetoStartx = random.randrange(0, largura)
			desvios +=1



		if y < objetoStarty+objetoAlt:
			#print("ultrapassou")

			if x > objetoStartx and x < objetoStartx + objetoLar or x+naveLar > objetoStartx and x+naveLar < objetoStartx+objetoLar:
				objetoStarty -= objetoStarty + 300
				objetoStartx = random.randrange(0, largura)	
				ponto = 0
				vida -=1
				
				print(vida)
				print("x crossover")				#setando a colisão
				if (vida == 0):
					bateu()
					vida = 2
					desvios = 0
					
		if balaY < objetoStarty+objetoAlt:			
			if balaX> objetoStartx and balaX< objetoStartx + objetoLar or balaX+balaLar > objetoStartx and balaX+balaLar< objetoStartx+objetoLar:
				seguir = True
				tiroVisivel = False
				ponto +=1
				objetoStarty -= objetoStarty + 300
				objetoStartx = random.randrange(0, largura)	
				
			
				
				
		if y < ybonus+bonuAlt:
			#print("ultrapassou")

			if xbonus > x and xbonus < x + naveLar or xbonus+bonusLar > x and xbonus+bonusLar < x+naveLar:
				ybonus -= ybonus + 300
				bonusVisivel = False
				xbonus = random.randrange(0, largura)	
				ponto = 0
				bonusEscolha =random.randrange(0, 100)
				if bonusEscolha < 50:
					acelerarNave += 5
					print("a nave acelerou")
				
				if bonusEscolha >50:
					vida += 1
					print("a vida aumentou")
					if vida == 4:
						bonusEscolha > 50
				
					
				
					
				
				

		for event in pygame.event.get():		#setando o click do mouse para fechar o jogo
			if event.type==QUIT:
				sair = False
				sys.exit()

			if event.type == pygame.KEYDOWN:		#tecla de movimentação para a direita
				if event.key == pygame.K_RIGHT:
					numNave = 1
					velX = acelerarNave

				elif event.key == pygame.K_LEFT:		#tecla de movimentação para a esquerda
					numNave = 2
					velX= -acelerarNave


			if event.type == pygame.KEYDOWN:			#tecla de movimentação para baixo
				if event.key == pygame.K_DOWN:
					numNave = 0
					velY = acelerarNave
			if event.type == pygame.KEYDOWN:			#tecla de movimentação para cima
				if event.key == pygame.K_UP:
					numNave = 0
					velY = -acelerarNave

				elif event.key == pygame.K_SPACE:		#tecla de espaço para atirar , não funcional
					seguir = False
					tiroVisivel = True
				
					
						
					
						
						

			if event.type == pygame.KEYUP:			#parar a movimentação quando não houver mais tecla pressionada
				if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
					numNave = 0
					velX = 0
				if event.key == pygame.K_DOWN or event.key == pygame.K_UP:
					velY = 0


		x+= velX
		y+= velY

		
		balas(balaX, balaY, balaLar, balaAlt)
		if tiroVisivel == True:
			balaY -= 15
			if balaY < 0:
				seguir = True
				tiroVisivel = False

		objetos(objetoStartx, objetoStarty, objetoLar, objetoAlt, cinza)	#chamando os atributos do objeto de colisão
		objetoStarty += objetoVel
		objetosDesviar(desvios)
		
		bon(xbonus, ybonus, bonusLar, bonuAlt)
		if (ponto ==1):
			bonusVisivel = True
			
		if bonusVisivel == True:
			pygame.draw.rect(DISPLAY,(0,255, 255),bonus)
			ybonus +=10
			if ybonus > altura:
				ybonus -= ybonus + 300
				xbonus = random.randrange(0, largura)	
				bonusVisivel = False
				
	
		relogio.tick(FPS)
		pygame.display.update()
	#game_loop()
	pygame.quit()
		

if __name__ =="__main__":
	main()




